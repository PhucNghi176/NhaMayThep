using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BaoHiemNhanVien.Create
{
    public class CreateBaoHiemNhanVienCommandHandler : IRequestHandler<CreateBaoHiemNhanVienCommand, string>
    {
        private readonly IBaoHiemNhanVienRepository _baoHiemNhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly INhanVienRepository _nhanVienRepository;

        public CreateBaoHiemNhanVienCommandHandler(ICurrentUserService currentUserService, IBaoHiemNhanVienRepository baoHiemNhanVienRepository, INhanVienRepository nhanVienRepository)
        {
            _baoHiemNhanVienRepository = baoHiemNhanVienRepository;
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<string> Handle(CreateBaoHiemNhanVienCommand request, CancellationToken cancellationToken)
        {
            var existingNhanVien = await _nhanVienRepository.AnyAsync(x => x.ID == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken);
            if (!existingNhanVien)
            {
                return "Thất Bại! Nhân viên không tồn tại.";
            }
            var existingBaoHiemNhanVien = await _baoHiemNhanVienRepository.AnyAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken);
            if (existingBaoHiemNhanVien)
            {
                return "Thất Bại! Bảo hiểm đã tồn tại cho nhân viên này.";
            }

            var baoHiemNhanVien = new BaoHiemNhanVienEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                Name = "",
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Now
            };

            _baoHiemNhanVienRepository.Add(baoHiemNhanVien);

            return await _baoHiemNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Thành Công!" : "Thất Bại!";
        }
    }
}
