using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.TrinhDoHocVan.Delete
{
    public class DeleteTrinhDoHocVanCommandHandler : IRequestHandler<DeleteTrinhDoHocVanCommand, string>
    {
        private readonly ITrinhDoHocVanRepository _trinhDoHocVanRepository;
        private readonly IMapper _mapper;

        public DeleteTrinhDoHocVanCommandHandler(ITrinhDoHocVanRepository trinhDoHocVanRepository, IMapper mapper)
        {
            _trinhDoHocVanRepository = trinhDoHocVanRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteTrinhDoHocVanCommand request, CancellationToken cancellationToken)
        {
            var trinhDoHocVan = await _trinhDoHocVanRepository.FindByIdAsync(request.Id, cancellationToken);
            if (trinhDoHocVan == null)
            {
                return "Fail";
            }
            trinhDoHocVan.NgayXoa = DateTime.Now;
            _trinhDoHocVanRepository.Update(trinhDoHocVan);
            await _trinhDoHocVanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return "Success";
        }
    }
}
