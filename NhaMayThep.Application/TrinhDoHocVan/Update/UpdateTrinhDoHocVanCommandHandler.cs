using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMapThep.Application.TrinhDoHocVan.Commands
{
    public class UpdateTrinhDoHocVanCommandHandler : IRequestHandler<UpdateTrinhDoHocVanCommand>
    {
        private readonly ITrinhDoHocVanRepository _repository;

        public UpdateTrinhDoHocVanCommandHandler(ITrinhDoHocVanRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTrinhDoHocVanCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException("TrinhDoHocVan Does Not Exist");
            }
            if (entity != null)
            {
                entity.Name = request.TenTrinhDo;
                entity.NguoiCapNhatID = request.NguoiCapNhatID;

                await _repository.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
