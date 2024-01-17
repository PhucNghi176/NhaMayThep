using AutoMapper;
using NhaMayThep.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Application.TrinhDoHocVan;
using NhaMayThep.Application.TrinhDoHocVan.GetAll;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.Application.TrinhDoHocVan.GetAll
{
    public class GetAllTrinhDoHocVanQueryHandler : IRequestHandler<GetAllQuery, List<TrinhDoHocVanDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITrinhDoHocVanRepository _trinhDoHocVanRepository;

        public GetAllTrinhDoHocVanQueryHandler(IMapper mapper, ITrinhDoHocVanRepository trinhDoHocVanRepository)
        {
            _mapper = mapper;
            _trinhDoHocVanRepository = trinhDoHocVanRepository;
        }

        public async Task<List<TrinhDoHocVanDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var listTrinhDoHocVan = await _trinhDoHocVanRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (listTrinhDoHocVan == null || listTrinhDoHocVan.Count == 0)
            {
                throw new NotFoundException("Does Not Have Any TrinhDoHocVan");
            }
            return listTrinhDoHocVan.MapToTrinhDoHocVanDtoList(_mapper);
        }
    }
}
