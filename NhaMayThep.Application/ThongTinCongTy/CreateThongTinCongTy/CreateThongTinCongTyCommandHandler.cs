using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
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
            var checkDuplicatoion = await _thongTinCongTyRepository.AnyAsync(x => x.MaDoanhNghiep == request.MaDoanhNghiep, cancellationToken: cancellationToken);
            if (checkDuplicatoion)
                throw new DuplicationException ("Thông Tin Công Ty đã tồn tại");

            var thongTinCongTy = new ThongTinCongTyEntity()
            {
                NguoiTaoID = _currentUserService.UserId,
                MaDoanhNghiep = request.MaDoanhNghiep,
                TenQuocTe = request.TenQuocTe,
                TenVietTat = request.TenVietTat,
                SoLuongNhanVien = request.SoLuongNhanVien,
                DiaChi = request.DiaChi,
                MaSoThue = request.MaSoThue,
                DienThoai = request.DienThoai,
                NguoiDaiDien = request.NguoiDaiDien,
                NgayHoatDong = DateTime.Today,
                DonViQuanLi = request.DonViQuanLi,
                LoaiHinhDoanhNghiep = request.LoaiHinhDoanhNghiep,
                TinhTrang = request.TinhTrang
            };

            _thongTinCongTyRepository.Add(thongTinCongTy);
            if (await _thongTinCongTyRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
