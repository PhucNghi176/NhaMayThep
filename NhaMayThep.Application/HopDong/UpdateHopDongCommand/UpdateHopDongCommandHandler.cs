using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.HopDong.UpdateHopDongCommand
{
    public class UpdateHopDongCommandHandler : IRequestHandler<UpdateHopDongCommand, HopDongDto>
    {
        private readonly IHopDongRepository _hopDongRepository;
        private readonly ICapBacLuongRepository _capBacLuongRepository;
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly ILoaiHopDongReposity _loaiHopDongRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateHopDongCommandHandler(IHopDongRepository hopDongRepository, IMapper mapper, ICapBacLuongRepository capBacLuongRepository
                                         , IChucDanhRepository chucDanhRepository, IChucVuRepository chucVuRepository, ILoaiHopDongReposity loaiHopDongReposity,
                                            ICurrentUserService currentUserService)
        {
            _hopDongRepository = hopDongRepository;
            _mapper = mapper;
            _capBacLuongRepository = capBacLuongRepository;
            _chucDanhRepository = chucDanhRepository;
            _chucVuRepository = chucVuRepository;
            _loaiHopDongRepository = loaiHopDongReposity;
            _currentUserService = currentUserService;
        }

        public async Task<HopDongDto> Handle(UpdateHopDongCommand command, CancellationToken cancellationToken)
        {

            var checkingHopDong = await _hopDongRepository.FindAnyAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            if (checkingHopDong == null)
                throw new NotFoundException($"Hợp đồng không hợp lệ");

            var CapBacLuong = await _capBacLuongRepository.FindAnyAsync(x => x.ID == command.HeSoLuongId && x.NgayXoa == null, cancellationToken);
            if (CapBacLuong == null)
                throw new NotFoundException($"Cấp bậc lương không hợp lệ {command.HeSoLuongId}");

            var ChucDanh = await _chucDanhRepository.FindAnyAsync(x => x.ID == command.ChucDanhId && x.NgayXoa == null, cancellationToken);
            if (ChucDanh == null)
                throw new NotFoundException($"Chức danh không hợp lệ{command.ChucDanhId}");

            var ChucVu = await _chucVuRepository.FindAnyAsync(x => x.ID == command.ChucVuId && x.NgayXoa == null, cancellationToken);
            if (ChucVu == null)
                throw new NotFoundException($"Chức vụ không hợp lệ{command.ChucVuId}");

            var LoaiHopDong = await _loaiHopDongRepository.FindAnyAsync(x => x.ID == command.LoaiHopDongId && x.NgayXoa == null, cancellationToken);
            if (LoaiHopDong == null)
                throw new NotFoundException($"Loại hợp đồng không hợp lệ{command.LoaiHopDongId}");

            checkingHopDong.LoaiHopDongID = command.LoaiHopDongId;
            checkingHopDong.LoaiHopDong = LoaiHopDong;
            checkingHopDong.NgayKy = command.NgayKyHopDong;
            checkingHopDong.NgayKetThuc = command.NgayKetThucHopDong;
            checkingHopDong.ThoiHanHopDong = command.ThoiHanHopDong;
            checkingHopDong.DiaDiemLamViec = command.DiaDiemLamViec;
            checkingHopDong.BoPhanLamViec = command.BoPhanLamViec;
            checkingHopDong.ChucDanhID = command.ChucDanhId;
            checkingHopDong.ChucDanh = ChucDanh;
            checkingHopDong.ChucVuID = command.ChucVuId;
            checkingHopDong.ChucVu = ChucVu;
            checkingHopDong.LuongCoBan = command.LuongCoBan;
            checkingHopDong.HeSoLuongID = command.HeSoLuongId;
            checkingHopDong.CapBacLuong = CapBacLuong;
            checkingHopDong.PhuCapID = command.PhuCapId;
            checkingHopDong.GhiChu = command.GhiChu;
            checkingHopDong.NgayCapNhatCuoi = DateTime.Now;
            checkingHopDong.NguoiCapNhatID = _currentUserService.UserId;
            _hopDongRepository.Update(checkingHopDong);
            await _hopDongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return checkingHopDong.MapToHopDongDto(_mapper);
        }
    }
}
