using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.TrinhDoHocVan.Delete
{
    public class DeleteTrinhDoHocVanCommandHandler : IRequestHandler<DeleteTrinhDoHocVanCommand, bool>
    {
        private readonly ITrinhDoHocVanRepository _trinhDoHocVanRepository;
        private readonly IMapper _mapper;

        public DeleteTrinhDoHocVanCommandHandler(ITrinhDoHocVanRepository trinhDoHocVanRepository, IMapper mapper)
        {
            _trinhDoHocVanRepository = trinhDoHocVanRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteTrinhDoHocVanCommand request, CancellationToken cancellationToken)
        {
            var trinhDoHocVan = await _trinhDoHocVanRepository.FindByIdAsync(request.Id, cancellationToken);
            if (trinhDoHocVan == null)
            {
                return false;
            }

            _trinhDoHocVanRepository.Remove(trinhDoHocVan);
            await _trinhDoHocVanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
