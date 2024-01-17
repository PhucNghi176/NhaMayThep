using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var checkingHopDong = await _hopDongRepository.FindAsync(x => x.ID == command.Id, cancellationToken);
            if (checkingHopDong == null)
                throw new NotFoundException($"Invalid HopDong {command.Id}");

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
