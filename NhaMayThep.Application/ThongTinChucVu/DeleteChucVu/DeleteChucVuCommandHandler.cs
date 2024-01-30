using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucVu.DeleteChucVu
{
    public class DeleteChucVuCommandHandler : IRequestHandler<DeleteChucVuCommand, string>
    {
        private readonly IChucVuRepository _chucVuRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteChucVuCommandHandler(IChucVuRepository chucVuRepository, ICurrentUserService currentUserService)
        {
            _chucVuRepository = chucVuRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteChucVuCommand command, CancellationToken cancellationToken)
        {
            var result = await _chucVuRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            var msg = "";
            if (result == null)
                throw new NotFoundException($"Không tìm thấy chức vự với id: {command.Id}");
            result.NgayXoa = DateTime.Now;
            result.NguoiXoaID = _currentUserService.UserId;
            if (await _chucVuRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                msg = "Xóa thành công";
            else
                msg = "Xóa thất bại";
            return msg;
        }
    }
}
