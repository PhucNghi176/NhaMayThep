using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongTy.CreateThongTinCongTy
{
    public class CreateThongTinCongTyCommandHandler : IRequestHandler<CreateThongTinCongTyCommand, string>
    {
        private readonly IThongTinCongTyRepository _thongTinCongTyRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateThongTinCongTyCommandHandler(IThongTinCongTyRepository thongTinCongTyRepository, ICurrentUserService currentUserService)
        {
            _thongTinCongTyRepository = thongTinCongTyRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateThongTinCongTyCommand request, CancellationToken cancellationToken)
        {
            var thongTinCongTy = new ThongTinCongTyEntity
            {
                Name = request.Name,
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
                TinhTrang = request.TinhTrang,
                NgayTao = DateTime.Now,
                NguoiTaoID = _currentUserService.UserId
            };
            _thongTinCongTyRepository.Add(thongTinCongTy);
            return await _thongTinCongTyRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Them thanh cong" : "Them that bai";
        }
    }
}