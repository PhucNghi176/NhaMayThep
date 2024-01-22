using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongTy.CreateThongTinCongTy
{
    public class CreateThongTinCongTyCommandHandler : IRequestHandler<CreateThongTinCongTyCommand, string>
    {
        private readonly IThongTinCongTyRepository _thongTinCongTyRepository;

        public CreateThongTinCongTyCommandHandler(IThongTinCongTyRepository thongTinCongTyRepository)
        {
            _thongTinCongTyRepository = thongTinCongTyRepository;
        }

        public async Task<string> Handle(CreateThongTinCongTyCommand request, CancellationToken cancellationToken)
        {
            var existTenQuocTe = await _thongTinCongTyRepository.AnyAsync(t => t.TenQuocTe == request.TenQuocTe, cancellationToken);
            if (existTenQuocTe) return "Ten quoc te exists";
            var existTenVietTat = await _thongTinCongTyRepository.AnyAsync(t => t.TenVietTat == request.TenVietTat, cancellationToken);
            if (existTenVietTat) return "Tet viet tat exists";
            var existMaSoThue = await _thongTinCongTyRepository.AnyAsync(t => t.MaSoThue == request.MaSoThue, cancellationToken);
            if (existMaSoThue) return "Ma so thue exists";
            var thongTinCongTy = new ThongTinCongTyEntity
            {
                TenQuocTe = request.TenQuocTe,
                TenVietTat = request.TenVietTat,
                SoLuongNhanVien = request.SoLuongNhanVien,
                DiaChi = request.DiaChi,
                MaSoThue = request.MaSoThue,
                DienThoai = request.DienThoai,
                NguoiDaiDien = request.NguoiDaiDien,
                NgayHoatDong = request.NgayHoatDong,
                DonViQuanLi = request.DonViQuanLi,
                LoaiHinhDoanhNghiep = request.LoaiHinhDoanhNghiep,
                TinhTrang = request.TinhTrang
            };
            _thongTinCongTyRepository.Add(thongTinCongTy);
            return await _thongTinCongTyRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Them thanh cong" : "Them that bai";
        }
    }
}