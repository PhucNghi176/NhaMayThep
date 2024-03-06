using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiCaLam.Update
{
    public class UpdateDangKiCaLamCommandHandler : IRequestHandler<UpdateDangKiCaLamCommand, DangKiCaLamDto>
    {
        private readonly IMapper _mapper;
        private readonly IDangKiCaLamRepository _repository;
        private readonly ICurrentUserService _currentUserService;
        private readonly INhanVienRepository _nhanVienRepository;

        public UpdateDangKiCaLamCommandHandler(IMapper mapper, IDangKiCaLamRepository repository, ICurrentUserService currentUserService, INhanVienRepository nhanVienRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<DangKiCaLamDto> Handle(UpdateDangKiCaLamCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID not found.");
            }

            var dangKiCaLam = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (dangKiCaLam == null)
            {
                throw new NotFoundException("DangKiCaLam does not exist.");
            }

            // Update properties directly, except for ThoiGianChamCongBatDau, ThoiGianChamCongKetThuc, and HeSoNgayCong
            dangKiCaLam.MaSoNhanVien = request.MaSoNhanVien;
            dangKiCaLam.NgayDangKi = request.NgayDangKi;
            dangKiCaLam.CaDangKi = request.CaDangKi;
            dangKiCaLam.ThoiGianCaLamBatDau = request.ThoiGianCaLamBatDau;
            dangKiCaLam.ThoiGianCaLamKetThuc = request.ThoiGianCaLamKetThuc;
            
            dangKiCaLam.MaSoNguoiQuanLy = request.MaSoNguoiQuanLy;
            dangKiCaLam.TrangThai = request.TrangThai;
            dangKiCaLam.GhiChu = request.GhiChu;
            dangKiCaLam.NguoiCapNhatID = userId;
            dangKiCaLam.NgayCapNhatCuoi = DateTime.UtcNow;

            _repository.Update(dangKiCaLam);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DangKiCaLamDto>(dangKiCaLam);
        }
    }
}
