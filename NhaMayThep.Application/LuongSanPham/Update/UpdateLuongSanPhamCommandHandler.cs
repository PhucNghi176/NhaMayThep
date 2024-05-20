using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongSanPham.Update
{
    public class UpdateLuongSanPhamCommandHandler : IRequestHandler<UpdateLuongSanPhamCommand, string>
    {
        private ILuongSanPhamRepository _LuongSanPhamRepository;
        private INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMucSanPhamRepository _mucSanPhamRepository;
        public UpdateLuongSanPhamCommandHandler(ILuongSanPhamRepository LuongSanPhamRepository, INhanVienRepository nhanVienRepository, IMapper mapper, ICurrentUserService currentUserService, IMucSanPhamRepository mucSanPhamRepository)
        {
            _LuongSanPhamRepository = LuongSanPhamRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _mucSanPhamRepository = mucSanPhamRepository;
        }
        public async Task<string> Handle(UpdateLuongSanPhamCommand request, CancellationToken cancellationToken)
        {
            if (request.MaSoNhanVien != null)
            {
                var nhanvien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
                if (nhanvien == null)
                    throw new NotFoundException($"Mã số nhân viên : {request.MaSoNhanVien} không tồn tại hoặc đã xóa.");
            }

            var LuongSanPham = await _LuongSanPhamRepository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (LuongSanPham == null)
                throw new NotFoundException($"Không tìm thấy Lương Sản Phẩm với ID : {request.ID} hoặc trường hợp này đã bị xóa.");

            var MucSanPham = await _mucSanPhamRepository.FindAsync(x => x.ID.Equals(request.MucSanPhamID) && x.NgayXoa == null, cancellationToken);
            if (MucSanPham == null)
                throw new NotFoundException($"Không tìm thấy Mức Sản Phẩm với ID : {request.MucSanPhamID} hoặc trường hợp này đã bị xóa.");

            var checkDuplication = await _LuongSanPhamRepository.FindAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.ID != request.ID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (checkDuplication != null)
                throw new NotFoundException("Nhan Vien co ID: " + request.MaSoNhanVien + "da ton tai Luong San Pham");

            LuongSanPham.SoSanPhamLam = request.SoSanPhamLam;
            LuongSanPham.MucSanPhamID = request.MucSanPhamID;
            LuongSanPham.TongLuong = request.TongLuong;
            LuongSanPham.NgayKhaiBao = request.NgayKhaiBao;
            LuongSanPham.NguoiCapNhatID = _currentUserService.UserId;
            LuongSanPham.NgayCapNhatCuoi = DateTime.Now;

            _LuongSanPhamRepository.Update(LuongSanPham);
            return await _LuongSanPhamRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật Lương Sản Phẩm thành công" : "Cập nhật Lương Sản Phẩm thất bại";
        }
    }
}
