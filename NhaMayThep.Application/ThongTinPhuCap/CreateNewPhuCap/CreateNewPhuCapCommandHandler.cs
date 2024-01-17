using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinPhuCap.CreateNewPhuCap
{
    public class CreateNewPhuCapCommandHandler : IRequestHandler<CreateNewPhuCapCommand, int>
    {
        private readonly IPhuCapRepository _phuCapRepository;
        public CreateNewPhuCapCommandHandler(IPhuCapRepository phuCapRepository)
        {
            _phuCapRepository = phuCapRepository;
        }
        public async Task<int> Handle(CreateNewPhuCapCommand command, CancellationToken cancellationToken)
        {
            var add = new ThongTinPhuCapEntity()
            {
                Name = command.TenPhuCap,
                PhanTramPhuCap = command.PhanTramPhuCap
            };
            _phuCapRepository.Add(add);
            await _phuCapRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return add.ID;
        }
    }
}
