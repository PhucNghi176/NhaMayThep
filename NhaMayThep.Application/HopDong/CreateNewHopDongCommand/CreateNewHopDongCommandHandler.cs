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
            var NhanVien = await _nhanVienRepository.FindAsync(x => x.ID == command.MaSoNhanVien, cancellationToken);
            if (NhanVien == null)
                throw new NotFoundException($"Invalid NhanVien {command.MaSoNhanVien}");
            var CapBacLuong = await _capBacLuongRepository.FindAsync(x => x.ID == command.HeSoLuongId, cancellationToken);
            if (CapBacLuong == null)
                throw new NotFoundException($"Invalid CapBacLuong {command.HeSoLuongId}");
            var ChucDanh = await _chucDanhRepository.FindAsync(x => x.ID == command.ChucDanhId, cancellationToken);
            if (ChucDanh == null)
                throw new NotFoundException($"Invalid ChucDanh {command.ChucDanhId}");
            var ChucVu = await _chucVuRepository.FindAsync(x => x.ID == command.ChucVuId, cancellationToken);
            if (ChucVu == null)
                throw new NotFoundException($"Invalid ChucDanh {command.ChucVuId}");
            var LoaiHopDong = await _loaiHopDongRepository.FindAsync(x => x.ID == command.LoaiHopDongId, cancellationToken);
            if (LoaiHopDong == null)
                throw new NotFoundException($"Invalid ChucDanh {command.LoaiHopDongId}");
            var checkingHopDong = await _hopDongRepository.FindAsync(x => x.NhanVienID == command.MaSoNhanVien, cancellationToken);
            if (checkingHopDong != null && checkingHopDong.NgayKetThuc < DateTime.UtcNow)
                throw new Exception("HopDong is still in time");
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
            await _hopDongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return HopDong.ID;
        }
    }
}
