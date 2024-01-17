using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
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
<<<<<<< HEAD
            var nhanvien = await _nhanvienRepository
                .FindAsync(x => x.ID.Equals(request.NhanVienID), cancellationToken);
            if(nhanvien == null || (nhanvien.NguoiXoaID != null && nhanvien.NgayXoa.HasValue))
=======
            var nhanvien = await _nhanvienRepository.FindAsync(x => x.ID.Equals(request.NhanVienID) && x.NguoiXoaID == null && x.NgayXoa == null, cancellationToken);
            if (nhanvien == null)
>>>>>>> origin/main
            {
                throw new NotFoundException("Nhân viên không tồn tại hoặc đã bị vô hiệu hóa");
            }
<<<<<<< HEAD
            var giamtru = await _thongTinGiamTruRepository
                   .FindAsync(x => x.ID == request.MaGiamTruID, cancellationToken);
            if (giamtru == null || (giamtru.NguoiXoaID != null && giamtru.NgayXoa.HasValue))
=======
            var giamtru = await _thongTinGiamTruRepository.FindAsync(x => x.ID == request.MaGiamTruID && x.NgayXoa == null && x.NguoiXoaID == null, cancellationToken);
            if (giamtru == null)
>>>>>>> origin/main
            {
                throw new NotFoundException("Giảm trừ gia cảnh không tồn tại hoặc đã bị vô hiệu hóa");
            }
<<<<<<< HEAD
            var cccd = await _canCuocCongDanRepository
                   .FindAsync(x => x.CanCuocCongDan == request.CanCuocCongDan, cancellationToken);
            if (cccd == null || (cccd.NguoiXoaID != null && cccd.NgayXoa.HasValue))
=======
            var cccd = await _canCuocCongDanRepository.FindAsync(x => x.CanCuocCongDan == request.CanCuocCongDan && x.NgayXoa == null && x.NguoiXoaID == null, cancellationToken);
            if (cccd == null)
>>>>>>> origin/main
            {
                throw new NotFoundException("Căn cước công dân không tồn tại hoặc đã bị vô hiệu hóa");
            }
            var thongtingiamtruCur = await _thongTinGiamTruGiaCanhRepository
                    .FindAsync(x => x.CanCuocCongDan == cccd.CanCuocCongDan, cancellationToken);
            if (thongtingiamtruCur != null || (thongtingiamtruCur !=null && thongtingiamtruCur.NguoiXoaID != null && thongtingiamtruCur.NgayXoa.HasValue))
            {
<<<<<<< HEAD
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
=======
                if (await _thongTinGiamTruGiaCanhRepository.FindAsync(x => x.CanCuocCongDan == cccd.CanCuocCongDan && x.NgayXoa == null && x.NguoiXoaID == null, cancellationToken) != null)
                {
                    throw new NotFoundException("ThongTinMienTruGiaCanh for this CanCuocCongDan already exists.");
                }
                var giamtrugiacanh = new ThongTinGiamTruGiaCanhEntity
                {
                    NguoiTaoID = request.NguoiTaoId,
                    NhanVienID = nhanvien.ID,
                    MaGiamTruID = giamtru.ID,
                    NhanVien = nhanvien,
                    ThongTinGiamTru = giamtru!,
                    DiaChiLienLac = request.DiaChiLienLac,
                    QuanHeVoiNhanVien = request.QuanHeVoiNhanVien,
                    CanCuocCongDan = cccd.CanCuocCongDan,
                    NgayXacNhanPhuThuoc = request.NgayXacNhanPhuThuoc
                };
                _thongTinGiamTruGiaCanhRepository.Add(giamtrugiacanh);
                var result = await _thongTinGiamTruGiaCanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (result > 0)
                {
                    return "Delete Successfully!";
                }
                else
                {
                    return "Delete Failed!";
                }
>>>>>>> origin/main
            }
        }
    }
}
