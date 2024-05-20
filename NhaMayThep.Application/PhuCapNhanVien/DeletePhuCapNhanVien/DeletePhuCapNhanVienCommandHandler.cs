using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhuCapNhanVien.DeletePhuCapNhanVien
{
    public class DeletePhuCapNhanVienCommandHandler : IRequestHandler<DeletePhuCapNhanVienCommand, string>
    {
        private readonly IPhuCapNhanVienRepository _phuCapNhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeletePhuCapNhanVienCommandHandler(
            IPhuCapNhanVienRepository phuCapNhanVienRepository,
            ICurrentUserService currentUserService)
        {
            _phuCapNhanVienRepository = phuCapNhanVienRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeletePhuCapNhanVienCommand request, CancellationToken cancellationToken)
        {
            var phuCapNhanVien = await _phuCapNhanVienRepository
                .FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (phuCapNhanVien == null || (phuCapNhanVien.NguoiXoaID != null && phuCapNhanVien.NgayXoa.HasValue))
            {
                throw new NotFoundException("Phụ cấp nhân viên không tồn tại hoặc đã bị vô hiệu hóa trước đó");
            }
            phuCapNhanVien.NguoiXoaID = _currentUserService.UserId;
            phuCapNhanVien.NgayXoa = DateTime.Now;
            _phuCapNhanVienRepository.Update(phuCapNhanVien);
            if (await _phuCapNhanVienRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Xóa thành công";
            else
                return "Xóa thất bại";
        }
    }
}
