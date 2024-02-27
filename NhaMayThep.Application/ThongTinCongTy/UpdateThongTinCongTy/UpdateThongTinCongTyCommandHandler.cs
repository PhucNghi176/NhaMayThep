using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinCongTy.UpdateThongTinCongTy;

namespace NhaMayThep.Application.ThongTinCongTy.UpdateThongTinCongTy
{
    public class UpdateThongTinCongTyCommandHandler : IRequestHandler<UpdateThongTinCongTyCommand, string>
    {
        private readonly IThongTinCongTyRepository _thongTinCongTyRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateThongTinCongTyCommandHandler(
            IThongTinCongTyRepository thongTinCongTyRepository,
            ICurrentUserService currentUserService)
        {
            _thongTinCongTyRepository = thongTinCongTyRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateThongTinCongTyCommand request, CancellationToken cancellationToken)
        {
            var thongTinCongTy = await _thongTinCongTyRepository
                .FindAsync(x => x.ID.Equals(request.ID), cancellationToken);
            if (thongTinCongTy == null || (thongTinCongTy.NguoiXoaID != null && thongTinCongTy.NgayXoa.HasValue))
            {
                throw new NotFoundException("Thông tin công ty không tồn tại hoặc đã bị vô hiệu hóa");
            }
            thongTinCongTy.NguoiCapNhatID = _currentUserService.UserId;
            thongTinCongTy.NgayCapNhatCuoi = DateTime.Now;
            thongTinCongTy.MaDoanhNghiep = request.MaDoanhNghiep;
            thongTinCongTy.TenQuocTe = request.TenQuocTe;
            thongTinCongTy.TenVietTat = request.TenVietTat;
            thongTinCongTy.SoLuongNhanVien = request.SoLuongNhanVien;
            thongTinCongTy.DiaChi = request.DiaChi;
            thongTinCongTy.MaSoThue = request.MaSoThue;
            thongTinCongTy.DienThoai = request.DienThoai;
            thongTinCongTy.NguoiDaiDien = request.NguoiDaiDien;
            thongTinCongTy.DonViQuanLi = request.DonViQuanLi;
            thongTinCongTy.LoaiHinhDoanhNghiep = request.LoaiHinhDoanhNghiep;
            thongTinCongTy.TinhTrang = request.TinhTrang;
            thongTinCongTy.NgayHoatDong = request.NgayHoatDong;
            _thongTinCongTyRepository.Update(thongTinCongTy);
            await _thongTinCongTyRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Cập nhật thành công";
        }
    }
}
