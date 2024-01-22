using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongTy.UpdateThongTinCongTy
{
    public class UpdateThongTinCongTyCommandHandler : IRequestHandler<UpdateThongTinCongTyCommand, string>
    {
        private readonly IThongTinCongTyRepository _thongTinCongTyRepository;

        public UpdateThongTinCongTyCommandHandler(IThongTinCongTyRepository thongTinCongTyRepository)
        {
            _thongTinCongTyRepository = thongTinCongTyRepository;
        }

        public async Task<string> Handle(UpdateThongTinCongTyCommand request, CancellationToken cancellationToken)
        {
            var thongTinCongTy = await _thongTinCongTyRepository.FindAsync(t => t.MaDoanhNghiep == request.MaDoanhNghiep, cancellationToken);
            if (thongTinCongTy is null)
                throw new NotFoundException($"Khong tim thay Id {request.MaDoanhNghiep}");
            thongTinCongTy.TenQuocTe = request.TenQuocTe;
            thongTinCongTy.TenVietTat = request.TenVietTat;
            thongTinCongTy.SoLuongNhanVien = request.SoLuongNhanVien;
            thongTinCongTy.DiaChi = request.DiaChi;
            thongTinCongTy.MaSoThue = request.MaSoThue;
            thongTinCongTy.DienThoai = request.DienThoai;
            thongTinCongTy.NguoiDaiDien = request.NguoiDaiDien;
            thongTinCongTy.NgayHoatDong = request.NgayHoatDong;
            thongTinCongTy.DonViQuanLi = request.DonViQuanLi;
            thongTinCongTy.LoaiHinhDoanhNghiep = request.LoaiHinhDoanhNghiep;
            thongTinCongTy.TinhTrang = request.TinhTrang;

            _thongTinCongTyRepository.Update(thongTinCongTy);

            return await _thongTinCongTyRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cap nhat thanh cong" : "Cap nhat that bai";
        }
    }
}