using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.CapBacLuong.DeleteCapBacLuong
{
    public class DeleteCapBacLuongCommandHandler : IRequestHandler<DeleteCapBacLuongCommand, string>
    {
        private readonly ICapBacLuongRepository _capBacLuongRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteCapBacLuongCommandHandler(ICapBacLuongRepository capBacLuongRepository, ICurrentUserService currentUserService)
        {
            _capBacLuongRepository = capBacLuongRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteCapBacLuongCommand request, CancellationToken cancellationToken)
        {
            var capBacLuong = await _capBacLuongRepository
                .FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (capBacLuong == null || (capBacLuong.NguoiXoaID != null && capBacLuong.NgayXoa.HasValue))
            {
                throw new NotFoundException("Cấp bậc lương không tồn tại hoặc đã bị vô hiệu hóa trước đó");
            }
            capBacLuong.NguoiXoaID = _currentUserService.UserId;
            capBacLuong.NgayXoa = DateTime.Now;
            _capBacLuongRepository.Update(capBacLuong);
            if (await _capBacLuongRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Xóa thành công";
            else
                return "Xóa thất bại";
        }
    }
}
