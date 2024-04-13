using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiCaLam.Create
{
    public class CreateDangKiCaLamCommandHandler : IRequestHandler<CreateDangKiCaLamCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IDangKiCaLamRepository _repository;
        private readonly ICurrentUserService _currentUserService;
        private readonly INhanVienRepository _nhanVienRepository;

        public CreateDangKiCaLamCommandHandler(IMapper mapper, IDangKiCaLamRepository repository, ICurrentUserService currentUserService, INhanVienRepository nhanVienRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<string> Handle(CreateDangKiCaLamCommand request, CancellationToken cancellationToken)
        {
            // Validate MaSoNhanVien
            var nhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);
            if (nhanVien == null || nhanVien.NgayXoa != null)
            {
                throw new NotFoundException("Nhan Vien không tồn tại hoặc đã bị xóa.");
            }

            // Validate MSNQL
            var nhanvienQuanLy = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNguoiQuanLy && x.NgayXoa == null, cancellationToken);
            if (nhanvienQuanLy == null)
            {
                throw new NotFoundException("Nguoi Quan Ly không tồn tại hoặc đã bị xóa.");
            }

            // HeSoNgayCong and ThoiGianChamCongBatDau/KetThuc handling moved to Check-in/Check-out

            var dangKiCaLam = new DangKiCaLamEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                NgayDangKi = request.NgayDangKi,
                CaDangKi = request.CaDangKi,
                ThoiGianCaLamBatDau = request.ThoiGianCaLamBatDau,
                ThoiGianCaLamKetThuc = request.ThoiGianCaLamKetThuc,
                // Initial values for check-in and check-out times
                ThoiGianChamCongBatDau = null,
                ThoiGianChamCongKetThuc = null,
                
                HeSoNgayCong = 0, 
                MaSoNguoiQuanLy = request.MaSoNguoiQuanLy,
                TrangThai = request.TrangThai,
                GhiChu = request.GhiChu,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Now
            };

            _repository.Add(dangKiCaLam);
           return await _repository.UnitOfWork.SaveChangesAsync(cancellationToken) >0 ? "Dang Ki Ca Lam thành công" : "Dang Ki Ca Lam thất bại";

        }
    }
}
