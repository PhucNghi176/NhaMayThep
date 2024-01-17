using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.CreateThongTinCongDoan
{
    public class CreateThongTinCongDoanCommandHandler : IRequestHandler<CreateThongTinCongDoanCommand, string>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateThongTinCongDoanCommandHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository, 
            INhanVienRepository nhanVienRepository,
            ICurrentUserService currentUserService) 
        {
            _nhanVienRepository = nhanVienRepository;
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateThongTinCongDoanCommand request, CancellationToken cancellationToken)
        {
            var nhanvien = await _nhanVienRepository
                .FindAsync(x=> x.ID.Equals(request.NhanVienID) && x.NguoiXoaID == null && x.NgayXoa == null, 
                cancellationToken);
            if(nhanvien == null)
            {
                throw new NotFoundException($"Không tồn tại nhân viên có Id {request.NhanVienID}");
            }
            if(await _thongtinCongDoanRepository
                .FindAsync(x=> x.ID.Equals(request.NhanVienID) && x.NguoiXoaID == null && x.NgayXoa == null, 
                cancellationToken) != null)
            {
                throw new NotFoundException($"Thông tin công đoàn cho nhân viên với Id {request.NhanVienID} đã tồn tại");
            }
            var thongtincongdoan = new ThongTinCongDoanEntity
            {
                NguoiTaoID= _currentUserService.UserId,
                ThuKiCongDoan = request.ThuKyCongDoan,
                NgayGiaNhap = request.NgayGiaNhap,
                NhanVien = nhanvien,
            };
            _thongtinCongDoanRepository.Add(thongtincongdoan);
            try
            {
                await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return "Tạo thành công";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi trong quá trình tạo";
            }
        }
    }
}
