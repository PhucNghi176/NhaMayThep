using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NghiPhep.Delete
{
    public class DeleteNghiPhepCommandHandler : IRequestHandler<DeleteNghiPhepCommand, string>
    {
        private readonly INghiPhepRepository _nghiPhepRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteNghiPhepCommandHandler(ICurrentUserService currentUserService, INghiPhepRepository nghiPhepRepository)
        {
            _nghiPhepRepository = nghiPhepRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var nghiPhep = await _nghiPhepRepository.FindAsync(x => x.ID == request.Id && x.NgayXoa == null, cancellationToken);

            if (nghiPhep == null)
            {
                return "Xóa Thất Bại! Không tìm thấy hoặc bản ghi đã bị xóa trước đó.";
            }

            nghiPhep.NgayXoa = DateTime.Now;
            nghiPhep.NguoiXoaID = _currentUserService.UserId;

            _nghiPhepRepository.Update(nghiPhep);
            await _nghiPhepRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return "Xóa Thành Công!";
        }
    }
}
