using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinPhuCap.DeletePhuCap
{
    public class DeletePhuCapCommandHandler : IRequestHandler<DeletePhuCapCommand, string>
    {
        private readonly IPhuCapRepository _phuCapRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeletePhuCapCommandHandler(IPhuCapRepository phuCapRepository, ICurrentUserService currentUserService)
        {
            _phuCapRepository = phuCapRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeletePhuCapCommand command, CancellationToken cancellationToken)
        {
            var result = await _phuCapRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            var msg = "";
            if (result == null)
                throw new NotFoundException($"Không tìm thấy phụ cấp với id: {command.Id}");
            result.NgayXoa = DateTime.Now;
            result.NguoiXoaID = _currentUserService.UserId;
            if (await _phuCapRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                msg = "Xóa thành công";
            else
                msg = "Xóa thất bại";
            return msg;
        }
    }
}
