using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

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
            var result = await _phuCapRepository.FindAsync(x => x.ID == command.Id, cancellationToken);
            var msg = "";
            if (result == null)
                throw new NotFoundException($"Phu cap with {command.Id} not found");
            result.NgayXoa = DateTime.Now;
            result.NguoiXoaID = _currentUserService.UserId;
            if (await _phuCapRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                msg = "Remove Successfully";
            else
                msg = "Remove Failed";
            return msg;
        }
    }
}
