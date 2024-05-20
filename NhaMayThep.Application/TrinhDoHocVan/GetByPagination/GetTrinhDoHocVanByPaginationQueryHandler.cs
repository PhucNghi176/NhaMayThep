using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.TrinhDoHocVan.GetByPagination
{
    public class GetTrinhDoHocVanByPaginationQueryHandler : IRequestHandler<GetTrinhDoHocVanByPaginationQuery, PagedResult<TrinhDoHocVanDto>>
    {
        private readonly ITrinhDoHocVanRepository _trinhDoHocVanRepository;
        private readonly IMapper _mapper;
        public GetTrinhDoHocVanByPaginationQueryHandler(ITrinhDoHocVanRepository trinhDoHocVanRepository, IMapper mapper)
        {
            _trinhDoHocVanRepository = trinhDoHocVanRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<TrinhDoHocVanDto>> Handle(GetTrinhDoHocVanByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _trinhDoHocVanRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<TrinhDoHocVanDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToTrinhDoHocVanDtoList(_mapper)
                );
        }
    }
}
