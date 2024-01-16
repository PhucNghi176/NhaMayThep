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
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        public UpdateThongTinCongDoanCommandHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository,
            ICurrentUserService currentUserService,
            INhanVienRepository nhanvienRepository,
            IMapper mapper)
        {
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
            _currentUserService = currentUserService;
            _nhanvienRepository = nhanvienRepository;
            _mapper = mapper;
        }
        public async Task<ThongTinCongDoanDto> Handle(UpdateThongTinCongDoanCommand request, CancellationToken cancellationToken)
        {
            var thongtincongdoan= await _thongtinCongDoanRepository.FindById(request.Id, cancellationToken);
            if (thongtincongdoan == null) 
            {
                throw new NotFoundException("ThongTinCongDoan does not exists");
            }
            var nhanvien = await _nhanvienRepository.FindById(request.NhanVienId, cancellationToken);
            if(nhanvien == null)
            {
                throw new NotFoundException($"Nhan vien with Id {request.NhanVienId} does not exists");
            }
            else
            {
                thongtincongdoan.NguoiCapNhatID = request.NguoiCapNhatid;
                thongtincongdoan.NhanVienID = nhanvien.ID;
                thongtincongdoan.NhanVien = nhanvien;
                thongtincongdoan.NgayCapNhatCuoi = DateTime.Now;
                thongtincongdoan.ThuKiCongDoan = request.ThuKyCongDoan;
                thongtincongdoan.NgayGiaNhap = request.NgayGiaNhap ?? thongtincongdoan.NgayGiaNhap;
                _thongtinCongDoanRepository.Update(thongtincongdoan);
                await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return thongtincongdoan.MapToThongTinCongDoanDto(_mapper);
            }
        }
    }
}
