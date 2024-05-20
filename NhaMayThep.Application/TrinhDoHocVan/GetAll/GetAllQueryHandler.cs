using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

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
                throw new NotFoundException("Không có Trình Độ Học Vấn nào!");
            }
            return listTrinhDoHocVan.MapToTrinhDoHocVanDtoList(_mapper);
        }
    }
}
