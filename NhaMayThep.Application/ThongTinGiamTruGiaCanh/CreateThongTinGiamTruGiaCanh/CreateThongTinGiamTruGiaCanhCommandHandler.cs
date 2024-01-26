using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.CreateThongTinGiamTruGiaCanh
{
    public class CreateThongTinGiamTruGiaCanhCommandHandler : IRequestHandler<CreateThongTinGiamTruGiaCanhCommand, string>
    {
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IThongTinGiamTruRepository _thongTinGiamTruRepository;
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateThongTinGiamTruGiaCanhCommandHandler(
            INhanVienRepository nhanVienRepository,
            IThongTinGiamTruRepository thongTinGiamTruRepository,
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            ICanCuocCongDanRepository canCuocCongDanRepository,
            ICurrentUserService currentUserService)
        {
            _nhanvienRepository = nhanVienRepository;
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _thongTinGiamTruRepository = thongTinGiamTruRepository;
            _canCuocCongDanRepository = canCuocCongDanRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateThongTinGiamTruGiaCanhCommand request, CancellationToken cancellationToken)
        {
            var nhanvien = await _nhanvienRepository
                .FindAsync(x => x.ID.Equals(request.NhanVienID), cancellationToken);
            if(nhanvien == null || (nhanvien.NguoiXoaID != null && nhanvien.NgayXoa.HasValue))
            {
                throw new NotFoundException("Nhân viên không tồn tại hoặc đã bị vô hiệu hóa");
            }
            var magiamtru = await _thongTinGiamTruRepository.FindAsync(x => x.ID == request.MaGiamTruID);
            if(magiamtru == null || (magiamtru.NguoiXoaID!= null && magiamtru.NgayXoa.HasValue))
            {
                throw new NotFoundException("Mã giảm trừ không tồn tại hoặc đã bị vô hiệu hóa");
            }
            var giamtru = await _thongTinGiamTruRepository
                   .FindAsync(x => x.ID == request.MaGiamTruID, cancellationToken);
            if (giamtru == null || (giamtru.NguoiXoaID != null && giamtru.NgayXoa.HasValue))
            {
                throw new NotFoundException("Giảm trừ gia cảnh không tồn tại hoặc đã bị vô hiệu hóa");
            }
            var cccd = await _canCuocCongDanRepository
                   .FindAsync(x => x.CanCuocCongDan == request.CanCuocCongDan, cancellationToken);
            if (cccd == null || (cccd.NguoiXoaID != null && cccd.NgayXoa.HasValue))
            {
                throw new NotFoundException("Căn cước công dân không tồn tại hoặc đã bị vô hiệu hóa");
            }
            if (!cccd.NhanVienID.Equals(nhanvien.ID))
            {
                throw new NotFoundException("Không đúng số căn cước công dân của nhân viên");
            }
            var thongtingiamtruCur = await _thongTinGiamTruGiaCanhRepository
                    .FindAsync(x => x.CanCuocCongDan == cccd.CanCuocCongDan, cancellationToken);
            if (thongtingiamtruCur != null)
            {
                throw new NotFoundException("Thông tin miễn trừ gia cảnh cho căn cước công dân này đã tồn tại hoặc đã bị vô hiệu hóa trước đó");
            }
            var giamtrugiacanh = new ThongTinGiamTruGiaCanhEntity
            {
                NguoiTaoID = _currentUserService.UserId,
                NhanVienID = nhanvien.ID,
                MaGiamTruID = giamtru.ID,
                NhanVien = nhanvien,
                ThongTinGiamTru = giamtru,
                DiaChiLienLac = request.DiaChiLienLac,
                QuanHeVoiNhanVien = request.QuanHeVoiNhanVien,
                CanCuocCongDan = cccd.CanCuocCongDan,
                NgayXacNhanPhuThuoc = request.NgayXacNhanPhuThuoc
            };
            _thongTinGiamTruGiaCanhRepository.Add(giamtrugiacanh);
            try
            {
                await _thongTinGiamTruGiaCanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return "Tạo thành công";
            }
            catch (Exception)
            {
                throw new NotFoundException("Đã xảy ra lỗi trong quá trình tạo");
            }
        }
    }
}
