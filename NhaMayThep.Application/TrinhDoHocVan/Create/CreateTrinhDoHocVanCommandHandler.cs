using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMapThep.Application.TrinhDoHocVan.Commands
{
    public class CreateTrinhDoHocVanCommandHandler : IRequestHandler<CreateTrinhDoHocVanCommand, int>
    {
        private readonly ITrinhDoHocVanRepository _repository;

        public CreateTrinhDoHocVanCommandHandler(ITrinhDoHocVanRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateTrinhDoHocVanCommand request, CancellationToken cancellationToken)
        {
            var trinhDoHocVanEntity = new TrinhDoHocVanEntity
            {
                Name = request.TenTrinhDo,
                NguoiTaoID = request.NguoiTaoID,
                NgayTao = request.NgayTao
                // Set other properties as needed
            };

            _repository.Add(trinhDoHocVanEntity);

            try
            {
                await _repository.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or throw custom exceptions as needed
                // Example: Log.Error($"Error saving TrinhDoHocVanEntity: {ex.Message}");
                throw;
            }

            return trinhDoHocVanEntity.ID;
        }
    }
}
