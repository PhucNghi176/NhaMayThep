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
            var nhanvien = await _nhanvienRepository.FindAsync(x => x.ID.Equals(request.NhanVienID) && x.NguoiXoaID == null && x.NgayXoa == null, cancellationToken);
            if (nhanvien == null)
            {
                throw new NotFoundException("NhanVien does not exists.");
            }
            var giamtru = await _thongTinGiamTruRepository.FindAsync(x => x.ID == request.MaGiamTruID && x.NgayXoa == null && x.NguoiXoaID == null, cancellationToken);
            if (giamtru == null)
            {
                throw new NotFoundException("GiamTruGiaCanh does not exists.");
            }
            var cccd = await _canCuocCongDanRepository.FindAsync(x => x.CanCuocCongDan == request.CanCuocCongDan && x.NgayXoa == null && x.NguoiXoaID == null, cancellationToken);
            if (cccd == null)
            {
                throw new NotFoundException("CanCuocCongDan does not exists.");
            }
            else
            {
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
            }
        }
    }
}
