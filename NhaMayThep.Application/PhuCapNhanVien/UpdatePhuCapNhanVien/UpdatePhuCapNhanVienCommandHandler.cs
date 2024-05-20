using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhuCapNhanVien.UpdatePhuCapNhanVien
{
    public class UpdatePhuCapNhanVienCommandHandler : IRequestHandler<UpdatePhuCapNhanVienCommand, string>
    {
        private readonly IPhuCapNhanVienRepository _phuCapNhanVienRepository;
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdatePhuCapNhanVienCommandHandler(
            IPhuCapNhanVienRepository phuCapNhanVienRepository,
            INhanVienRepository nhanvienRepository,
            ICurrentUserService currentUserService)
        {
            _phuCapNhanVienRepository = phuCapNhanVienRepository;
            _nhanvienRepository = nhanvienRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdatePhuCapNhanVienCommand request, CancellationToken cancellationToken)
        {
            var phuCapNhanVien = await _phuCapNhanVienRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (phuCapNhanVien == null || (phuCapNhanVien.NguoiXoaID != null && phuCapNhanVien.NgayXoa.HasValue))
            {
                throw new NotFoundException("Phụ cấp nhân viên không tồn tại hoặc đã bị vô hiệu hóa");
            }
            var nhanVien = await _nhanvienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien), cancellationToken);
            if (nhanVien == null || (nhanVien.NguoiXoaID != null && nhanVien.NgayXoa.HasValue))
            {
                throw new NotFoundException("Nhân viên không tồn tại hoặc đã bị vô hiệu hóa");
            }
            var checkDuplication = await _phuCapNhanVienRepository.AnyAsync(x => x.PhuCap.Equals(request.PhuCap), cancellationToken);
            if (checkDuplication)
            {
                throw new DuplicationException("Phụ Cấp này đã tồn tại");
            }
            phuCapNhanVien.NguoiCapNhatID = _currentUserService.UserId;
            phuCapNhanVien.NgayCapNhatCuoi = DateTime.Now;
            phuCapNhanVien.PhuCap = request.PhuCap;
            _phuCapNhanVienRepository.Update(phuCapNhanVien);
            if (await _phuCapNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
