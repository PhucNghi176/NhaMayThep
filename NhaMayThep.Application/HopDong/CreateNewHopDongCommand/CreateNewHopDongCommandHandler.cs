using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.HopDong.CreateNewHopDongCommand
{
    public class CreateNewHopDongCommandHandler : IRequestHandler<CreateNewHopDongCommand, string>
    {
        private readonly IHopDongRepository _hopDongRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICapBacLuongRepository _capBacLuongRepository;
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly ILoaiHopDongReposity _loaiHopDongRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateNewHopDongCommandHandler(IHopDongRepository hopDongRepository, INhanVienRepository nhanVienRepository, ICapBacLuongRepository capBacLuongRepository
                                            , ILoaiHopDongReposity loaiHopDongRepository, IChucDanhRepository chucDanhRepository, IChucVuRepository chucVuRepositoroy,
                                              ICurrentUserService currentUserService)
        {
            _hopDongRepository = hopDongRepository;
            _nhanVienRepository = nhanVienRepository;
            _capBacLuongRepository = capBacLuongRepository;
            _loaiHopDongRepository = loaiHopDongRepository;
            _chucDanhRepository = chucDanhRepository;
            _chucVuRepository = chucVuRepositoroy;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateNewHopDongCommand command, CancellationToken cancellationToken)
        {
            var NhanVien = await _nhanVienRepository.FindAsync(x => x.ID == command.MaSoNhanVien && x.NgayXoa == null, cancellationToken);
            if (NhanVien == null)
                throw new NotFoundException($"Nhân viên không hợp lệ {command.MaSoNhanVien}");
            var CapBacLuong = await _capBacLuongRepository.FindAsync(x => x.ID == command.HeSoLuongId && x.NgayXoa == null, cancellationToken);
            if(CapBacLuong == null)
                throw new NotFoundException($"Cấp bậc lương không hợp lệ {command.HeSoLuongId}");

            var ChucDanh = await _chucDanhRepository.FindAsync(x => x.ID == command.ChucDanhId && x.NgayXoa == null, cancellationToken);
            if (ChucDanh == null)
                throw new NotFoundException($"Chức danh không hợp lệ {command.ChucDanhId}");
            var ChucVu = await _chucVuRepository.FindAsync(x => x.ID == command.ChucVuId && x.NgayXoa == null, cancellationToken);
            if (ChucVu == null)
                throw new NotFoundException($"Chức vụ không hợp lệ {command.ChucVuId}");
            var LoaiHopDong = await _loaiHopDongRepository.FindAsync(x => x.ID == command.LoaiHopDongId && x.NgayXoa == null, cancellationToken);
            if (LoaiHopDong == null)
                throw new NotFoundException($"Loại hợp đồng không hợp lệ {command.LoaiHopDongId}");
            var checkingHopDong = await _hopDongRepository.FindAsync(x => x.NhanVienID == command.MaSoNhanVien && x.NgayXoa == null, cancellationToken);
            if (checkingHopDong != null && checkingHopDong.NgayKetThuc < DateTime.UtcNow)
                throw new Exception("Hợp đồng cho nhân viên vẫn đang có hiệu lực");
            var HopDong = new HopDongEntity()
            {
                NhanVienID = command.MaSoNhanVien,
                NhanVien = NhanVien,
                LoaiHopDongID = command.LoaiHopDongId,
                LoaiHopDong = LoaiHopDong,
                NgayKy = command.NgayKyHopDong,
                NgayKetThuc = command.NgayKetThucHopDong,
                ThoiHanHopDong = command.ThoiHanHopDong,
                DiaDiemLamViec = command.DiaDiemLamViec,
                BoPhanLamViec = command.BoPhanLamViec,
                ChucDanhID = command.ChucDanhId,
                ChucDanh = ChucDanh,
                ChucVuID = command.ChucVuId,
                ChucVu = ChucVu,
                LuongCoBan = command.LuongCoBan,
                HeSoLuongID = command.HeSoLuongId,
                CapBacLuong = CapBacLuong,
                PhuCapID = command.PhuCapId,
                GhiChu = command.GhiChu,
                NgayTao = DateTime.Now,
                NguoiTaoID = _currentUserService.UserId
            };

            _hopDongRepository.Add(HopDong);
            NhanVien.DaCoHopDong = true;
            _nhanVienRepository.Update(NhanVien);
            if (await _hopDongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
