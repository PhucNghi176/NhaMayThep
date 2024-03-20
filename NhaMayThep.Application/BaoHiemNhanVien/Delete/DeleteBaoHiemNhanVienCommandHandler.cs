using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.BaoHiemNhanVien.Delete
{
    public class DeleteBaoHiemNhanVienCommandHandler : IRequestHandler<DeleteBaoHiemNhanVienCommand, string>
    {
        private readonly IBaoHiemNhanVienRepository _baoHiemNhanVienRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteBaoHiemNhanVienCommandHandler(ICurrentUserService currentUserService, IBaoHiemNhanVienRepository baoHiemNhanVienRepository)
        {
            _currentUserService = currentUserService;
            _baoHiemNhanVienRepository = baoHiemNhanVienRepository;
        }

        public async Task<string> Handle(DeleteBaoHiemNhanVienCommand request, CancellationToken cancellationToken)
        {
            var baoHiemNhanVien = await _baoHiemNhanVienRepository.FindAsync(x => x.ID == request.Id && x.NgayXoa == null, cancellationToken);

            if (baoHiemNhanVien == null)
            {
                return "Xóa Thất Bại! Không tìm thấy hoặc bản ghi đã bị xóa trước đó.";
            }

            baoHiemNhanVien.NgayXoa = DateTime.Now;
            baoHiemNhanVien.NguoiXoaID = _currentUserService.UserId;

            _baoHiemNhanVienRepository.Update(baoHiemNhanVien);
            await _baoHiemNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return "Xóa Thành Công!";
        }
    }
}
