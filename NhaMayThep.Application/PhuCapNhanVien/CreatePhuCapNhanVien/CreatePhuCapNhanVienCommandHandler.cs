using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhuCapNhanVien.CreatePhuCapNhanVien
{
    public class CreatePhuCapNhanVienCommandHandler : IRequestHandler<CreatePhuCapNhanVienCommand, string>
    {
        private readonly IPhuCapNhanVienRepository _phuCapNhanVienRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreatePhuCapNhanVienCommandHandler(IPhuCapNhanVienRepository phuCapNhanVienRepository, ICurrentUserService currentUserService, INhanVienRepository nhanVienRepository)
        {
            _phuCapNhanVienRepository = phuCapNhanVienRepository;
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;
        }
        public async Task<string> Handle(CreatePhuCapNhanVienCommand request, CancellationToken cancellationToken)
        {
            var nhanVien = await _nhanVienRepository.AnyAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (!nhanVien)
                throw new NotFoundException("Nhân viên này không tồn tại");
            var checkDuplicatoion = await _phuCapNhanVienRepository.AnyAsync(x => x.PhuCap == request.PhuCap && x.NgayXoa == null, cancellationToken);
            if (checkDuplicatoion)
                throw new DuplicationException("Phụ cấp nhân viên đã tồn tại");

            var phuCapNhanVien = new PhuCapNhanVienEntity()
            {
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Now,
                MaSoNhanVien = request.MaSoNhanVien,
                PhuCap = request.PhuCap
            };

            _phuCapNhanVienRepository.Add(phuCapNhanVien);
            if (await _phuCapNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
