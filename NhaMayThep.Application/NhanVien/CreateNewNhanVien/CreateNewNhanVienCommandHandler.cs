using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.NhanVien.CreateNewNhanVienCommand
{
    public class CreateNewNhanVienCommandHandler : IRequestHandler<CreateNewNhanVienCommand, string>
    {
        private readonly INhanVienRepository _repository;

        public CreateNewNhanVienCommandHandler(INhanVienRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateNewNhanVienCommand request, CancellationToken cancellationToken)
        {
            var nv = new NhanVienEntity
            {
                ChucVuID = request.ChucVuID,
                DiaChiLienLac = request.DiaChiLienLac,
                Email = request.Email,
                HoVaTen = request.HoVaTen,
                MaSoThue = request.MaSoThue,
                NgayVaoCongTy = request.NgayVaoCongTy,
                PasswordHash = _repository.HashPassword(request.Password),
                SoDienThoaiLienLac = request.SoDienThoaiLienLac,
                SoNguoiPhuThuoc = request.SoNguoiPhuThuoc,
                SoTaiKhoan = request.SoTaiKhoan,
                TenNganHang = request.TenNganHang,
                TinhTrangLamViecID = request.TinhTrangLamViecID
            };
            _repository.Add(nv);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Success";
        }
    }
}
