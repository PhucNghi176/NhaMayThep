using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongThoiGian.UpdateLuongThoiGian
{
    public class UpdateLuongThoiGianCommandHandler : IRequestHandler<UpdateLuongThoiGianCommand, string>
    {
        private readonly ILuongThoiGianRepository _luongThoiGianRepository;
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateLuongThoiGianCommandHandler(
            ILuongThoiGianRepository luongThoiGianRepository,
            INhanVienRepository nhanvienRepository,
            ICurrentUserService currentUserService)
        {
            _luongThoiGianRepository = luongThoiGianRepository;
            _nhanvienRepository = nhanvienRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateLuongThoiGianCommand request, CancellationToken cancellationToken)
        {
            var luongThoiGian = await _luongThoiGianRepository.FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (luongThoiGian == null || (luongThoiGian.NguoiXoaID != null && luongThoiGian.NgayXoa.HasValue))
            {
                throw new NotFoundException("Lương thời gian không tồn tại hoặc đã bị vô hiệu hóa");
            }
            var nhanVien = await _nhanvienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien), cancellationToken);
            if (nhanVien == null || (nhanVien.NguoiXoaID != null && nhanVien.NgayXoa.HasValue))
            {
                throw new NotFoundException("Nhân viên không tồn tại hoặc đã bị vô hiệu hóa");
            }
            luongThoiGian.NguoiCapNhatID = _currentUserService.UserId;
            luongThoiGian.NgayCapNhatCuoi = DateTime.Now;
            luongThoiGian.MaLuongThoiGian = request.MaLuongThoiGian;
            luongThoiGian.NgayApDung = request.NgayApDung;
            luongThoiGian.LuongNam = request.LuongNam;
            luongThoiGian.LuongThang = request.LuongThang;
            luongThoiGian.LuongTuan = request.LuongTuan;
            luongThoiGian.LuongNgay = request.LuongNgay;
            luongThoiGian.LuongGio = request.LuongGio;
            _luongThoiGianRepository.Update(luongThoiGian);
            if (await _luongThoiGianRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
