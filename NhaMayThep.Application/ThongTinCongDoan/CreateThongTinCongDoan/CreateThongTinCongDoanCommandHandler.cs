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
        public CreateThongTinCongDoanCommandHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository,
            INhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
        }
        public async Task<string> Handle(CreateThongTinCongDoanCommand request, CancellationToken cancellationToken)
        {
            var nhanvien = await _nhanVienRepository.FindAsync(x => x.ID.Equals(request.NhanVienID) && x.NguoiXoaID == null && x.NgayXoa == null, cancellationToken);
            if (nhanvien == null)
            {
                throw new NotFoundException("NhanVien Does not exists");
            }
            if (await _thongtinCongDoanRepository.FindAsync(x => x.ID.Equals(request.NhanVienID) && x.NguoiXoaID == null && x.NgayXoa == null, cancellationToken) != null)
            {
                throw new NotFoundException("ThongTinCongDoan for this NhanVien exists");
            }
            var thongtincongdoan = new ThongTinCongDoanEntity
            {
                NguoiTaoID = request.NguoiTaoId,
                ThuKiCongDoan = request.ThuKyCongDoan,
                NgayGiaNhap = request.NgayGiaNhap,
                NhanVien = nhanvien,
            };
            _thongtinCongDoanRepository.Add(thongtincongdoan);
            var result = await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return "Delete Successfully!";
            }
            else
            {
                return "Delete Failed!";
            }
        }
    }
}
