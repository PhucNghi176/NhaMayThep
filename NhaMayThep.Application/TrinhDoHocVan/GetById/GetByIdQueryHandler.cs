using AutoMapper;
using NhaMayThep.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Application.TrinhDoHocVan;
using NhaMayThep.Application.TrinhDoHocVan.GetById;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.Application.TrinhDoHocVan.GetById
{
    public class GetByIdTrinhDoHocVanQueryHandler : IRequestHandler<GetByIdQuery, TrinhDoHocVanDto>
    {
        private readonly IMapper _mapper;
        private readonly ITrinhDoHocVanRepository _trinhDoHocVanRepository;

        public GetByIdTrinhDoHocVanQueryHandler(IMapper mapper, ITrinhDoHocVanRepository trinhDoHocVanRepository)
        {
            _mapper = mapper;
            _trinhDoHocVanRepository = trinhDoHocVanRepository;
        }

        public async Task<TrinhDoHocVanDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var trinhDoHocVan = await _trinhDoHocVanRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (trinhDoHocVan == null || trinhDoHocVan.NgayXoa != null)
            {
                throw new NotFoundException("TrinhDoHocVan Does not Exist");
            }
            return trinhDoHocVan.MapToTrinhDoHocVanDto(_mapper);
        }
    }
}
