using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongSanPham.Create
{
    public class CreateLuongSanPhamCommandHandler : IRequestHandler<CreateLuongSanPhamCommand, string>
    {
        private ILuongSanPhamRepository _LuongSanPhamRepository;
        private INhanVienRepository _nhanVienRepository;
        private IMucSanPhamRepository _mucSanPhamRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateLuongSanPhamCommandHandler(ILuongSanPhamRepository LuongSanPhamRepository, INhanVienRepository nhanVienRepository, IMucSanPhamRepository mucSanPhamRepository, ICurrentUserService currentUserService)
        {
            _LuongSanPhamRepository = LuongSanPhamRepository;
            _nhanVienRepository = nhanVienRepository;
            _mucSanPhamRepository = mucSanPhamRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateLuongSanPhamCommand request, CancellationToken cancellationToken)
        {
            var nhanVien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException($"Mã số nhân viên : {request.MaSoNhanVien} không tồn tại hoặc đã xóa.");

            var checkDuplicatoion = await _LuongSanPhamRepository.FindAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (checkDuplicatoion != null)
                throw new NotFoundException("Nhan Vien" + request.MaSoNhanVien + "da ton tai Luong San Pham");



            var mucSanPham = await _mucSanPhamRepository.FindAsync(x => x.ID == request.MucSanPhamID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (mucSanPham == null)
                throw new NotFoundException("Mức Sản Phẩm Id: " + request.MucSanPhamID + " không tìm thấy");

            var LuongSanPham = new LuongSanPhamEntity()
            {

                MaSoNhanVien = nhanVien.ID,

                MucSanPhamID = request.MucSanPhamID,

                TongLuong = request.TongLuong,
                SoSanPhamLam = request.SoSanPhamLam,
                NgayKhaiBao = request.NgayKhaiBao,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Today
            };

            _LuongSanPhamRepository.Add(LuongSanPham);
            return await _LuongSanPhamRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo Lương Sản Phẩm thành công" : "Tạo Lương Sản Phẩm thất bại";
        }
    }
}