using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Infrastructure.Persistence;

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
                .FindAnyAsync(x=> x.ID.Equals(request.NhanVienID), cancellationToken);
            if(nhanvien == null || (nhanvien.NguoiXoaID != null && nhanvien.NgayXoa.HasValue))
            {
                throw new NotFoundException($"Nhân viên không tồn tại hoặc đã bị vô hiệu hóa");
            }
            var thongtincongdoan = await _thongtinCongDoanRepository
                     .FindAnyAsync(x => x.NhanVienID.Equals(request.NhanVienID), cancellationToken);
            if (thongtincongdoan != null)
            {
                throw new NotFoundException($"Thông tin công đoàn đã tồn tại hoặc đã bị vô hiệu hóa trước đó");
            }
            var thongtincongdoanNew = new ThongTinCongDoanEntity
            {
                NguoiTaoID = _currentUserService.UserId,
                ThuKiCongDoan = request.ThuKyCongDoan,
                NgayGiaNhap = request.NgayGiaNhap,
                NhanVien = nhanvien,
            };
            _thongtinCongDoanRepository.Add(thongtincongdoanNew);
            try
            {
                await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return "Tạo thông tin công đoàn thành công";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi trong quá trình tạo thông tin công đoàn";
            }
        }
    }
}
