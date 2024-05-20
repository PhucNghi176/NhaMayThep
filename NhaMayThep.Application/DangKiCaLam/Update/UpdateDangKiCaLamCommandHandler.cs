using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.DangKiCaLam.Update
{
    public class UpdateDangKiCaLamCommandHandler : IRequestHandler<UpdateDangKiCaLamCommand, string>
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

        public async Task<string> Handle(UpdateDangKiCaLamCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID không thấy.");
            }

            var dangKiCaLam = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (dangKiCaLam == null)
            {
                throw new NotFoundException("DangKiCaLam không tồn tại.");
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

            return await _repository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật Đăng Kí Ca Làm thành công" : "Cập nhật Đăng Kí Ca Làm thất bại";
        }
    }
}
