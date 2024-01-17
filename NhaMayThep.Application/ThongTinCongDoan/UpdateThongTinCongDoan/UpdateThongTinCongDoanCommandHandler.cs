using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan
{
    public class UpdateThongTinCongDoanCommandHandler : IRequestHandler<UpdateThongTinCongDoanCommand, ThongTinCongDoanDto>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateThongTinCongDoanCommandHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository,
            INhanVienRepository nhanvienRepository,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
            _nhanvienRepository = nhanvienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<ThongTinCongDoanDto> Handle(UpdateThongTinCongDoanCommand request, CancellationToken cancellationToken)
        {
            var thongtincongdoan= await _thongtinCongDoanRepository
                .FindAsync(x => x.ID.Equals(request.Id) && x.NguoiXoaID == null && x.NgayXoa.HasValue, 
                cancellationToken);
            if (thongtincongdoan == null) 
            {
                throw new NotFoundException("Thông tin công đoàn không tồn tại");
            }
            var nhanvien = await _nhanvienRepository
                .FindAsync(x => x.ID.Equals(request.NhanVienId) && x.NguoiXoaID == null && x.NgayXoa.HasValue, 
                cancellationToken);
            if(nhanvien == null)
            {
                throw new NotFoundException($"Không tồn tại nhân viên với Id {request.NhanVienId}");
            }
            else
            {
                thongtincongdoan.NguoiCapNhatID = _currentUserService.UserId;
                thongtincongdoan.NhanVienID = nhanvien.ID;
                thongtincongdoan.NhanVien = nhanvien;
                thongtincongdoan.NgayCapNhatCuoi = DateTime.Now;
                thongtincongdoan.ThuKiCongDoan = request.ThuKyCongDoan;
                thongtincongdoan.NgayGiaNhap = request.NgayGiaNhap ?? thongtincongdoan.NgayGiaNhap;
                _thongtinCongDoanRepository.Update(thongtincongdoan);
                try
                {
                    await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                    return thongtincongdoan.MapToThongTinCongDoanDto(_mapper);
                }
                catch (Exception)
                {
                    throw new NotFoundException("Đã xảy ra lỗi trong quá trình cập nhật dữ liệu");
                }
            }
        }
    }
}
