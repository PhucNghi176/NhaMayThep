using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Application.ThongTinCongDoan.CreateThongTinCongDoan
{
    public class CreateThongTinCongDoanCommandHandler : IRequestHandler<CreateThongTinCongDoanCommand, string>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateThongTinCongDoanCommandHandler(
<<<<<<< HEAD
            IThongTinCongDoanRepository thongTinCongDoanRepository, 
            INhanVienRepository nhanVienRepository,
            ICurrentUserService currentUserService) 
=======
            IThongTinCongDoanRepository thongTinCongDoanRepository,
            INhanVienRepository nhanVienRepository)
>>>>>>> origin/main
        {
            _nhanVienRepository = nhanVienRepository;
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateThongTinCongDoanCommand request, CancellationToken cancellationToken)
        {
<<<<<<< HEAD
            var nhanvien = await _nhanVienRepository
                .FindAsync(x=> x.ID.Equals(request.NhanVienID), cancellationToken);
            if(nhanvien == null || (nhanvien.NguoiXoaID != null && nhanvien.NgayXoa.HasValue))
=======
            var nhanvien = await _nhanVienRepository.FindAsync(x => x.ID.Equals(request.NhanVienID) && x.NguoiXoaID == null && x.NgayXoa == null, cancellationToken);
            if (nhanvien == null)
>>>>>>> origin/main
            {
                throw new NotFoundException($"Nhân viên không tồn tại hoặc đã bị vô hiệu hóa");
            }
<<<<<<< HEAD
            var thongtincongdoan = await _thongtinCongDoanRepository
                     .FindAsync(x => x.NhanVienID.Equals(request.NhanVienID), cancellationToken);
            if (thongtincongdoan != null || (thongtincongdoan != null && thongtincongdoan.NguoiXoaID != null && thongtincongdoan.NgayXoa.HasValue))
=======
            if (await _thongtinCongDoanRepository.FindAsync(x => x.ID.Equals(request.NhanVienID) && x.NguoiXoaID == null && x.NgayXoa == null, cancellationToken) != null)
>>>>>>> origin/main
            {
                throw new NotFoundException($"Thông tin công đoàn đã tồn tại hoặc đã bị vô hiệu hóa trước đó");
            }
            var thongtincongdoanNew = new ThongTinCongDoanEntity
            {
<<<<<<< HEAD
                NguoiTaoID = _currentUserService.UserId,
=======
                NguoiTaoID = request.NguoiTaoId,
>>>>>>> origin/main
                ThuKiCongDoan = request.ThuKyCongDoan,
                NgayGiaNhap = request.NgayGiaNhap,
                NhanVien = nhanvien,
            };
<<<<<<< HEAD
            _thongtinCongDoanRepository.Add(thongtincongdoanNew);
            try
=======
            _thongtinCongDoanRepository.Add(thongtincongdoan);
            var result = await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
>>>>>>> origin/main
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
