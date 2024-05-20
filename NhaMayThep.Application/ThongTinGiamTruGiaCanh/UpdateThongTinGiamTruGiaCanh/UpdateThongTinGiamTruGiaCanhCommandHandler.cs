using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.UpdateThongTinGiamTruGiaCanh
{
    public class UpdateThongTinGiamTruGiaCanhCommandHandler : IRequestHandler<UpdateThongTinGiamTruGiaCanhCommand, string>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IThongTinGiamTruRepository _thongTinGiamTruRepository;
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateThongTinGiamTruGiaCanhCommandHandler(
            IThongTinGiamTruRepository thongTinGiamTruRepository,
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            ICanCuocCongDanRepository canCuocCongDanRepository,
            ICurrentUserService currentUserService)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _thongTinGiamTruRepository = thongTinGiamTruRepository;
            _canCuocCongDanRepository = canCuocCongDanRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateThongTinGiamTruGiaCanhCommand request, CancellationToken cancellationToken)
        {
            var giamtru = await _thongTinGiamTruRepository
                .FindAsync(x => x.ID.Equals(request.MaGiamTruID), cancellationToken);
            if (giamtru == null || (giamtru.NguoiXoaID != null && giamtru.NgayXoa.HasValue))
            {
                throw new NotFoundException("Thông tin giảm trừ không tồn tại hoặc đã bị vô hiệu hóa");
            }
            var thongtingiamtru = await _thongTinGiamTruGiaCanhRepository
                .FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (thongtingiamtru == null || (thongtingiamtru.NguoiXoaID != null && thongtingiamtru.NgayXoa.HasValue))
            {
                throw new NotFoundException("Thông tin giảm trừ gia cảnh không tồn tại hoặc đã bị vô hiệu hóa");
            }
            var cccd = await _canCuocCongDanRepository
                    .FindAsync(x => x.CanCuocCongDan.Equals(request.CanCuocCongDan), cancellationToken);
            if (cccd == null || (cccd.NguoiXoaID != null && cccd.NgayXoa.HasValue))
            {
                throw new NotFoundException($"Căn cước công dân {request.CanCuocCongDan} không tồn tại hoặc đã bị vô hiệu hóa trước đó");
            }
            if (!cccd.NhanVienID.Equals(thongtingiamtru.NhanVienID))
            {
                throw new NotFoundException($"Căn cước công dân không phải của nhân viên này");
            }
            thongtingiamtru.NguoiCapNhatID = _currentUserService.UserId;
            thongtingiamtru.NgayCapNhatCuoi = DateTime.Now;
            thongtingiamtru.MaGiamTruID = giamtru.ID;
            thongtingiamtru.ThongTinGiamTru = giamtru;
            thongtingiamtru.DiaChiLienLac = request.DiaChiLienLac ?? thongtingiamtru.DiaChiLienLac;
            thongtingiamtru.QuanHeVoiNhanVien = request.QuanHeVoiNhanVien ?? thongtingiamtru.DiaChiLienLac;
            thongtingiamtru.CanCuocCongDan = cccd.CanCuocCongDan;
            thongtingiamtru.NgayXacNhanPhuThuoc = request.NgayXacNhanPhuThuoc;
            _thongTinGiamTruGiaCanhRepository.Update(thongtingiamtru);
            return await _thongTinGiamTruGiaCanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhậ thất bại";
        }
    }
}
