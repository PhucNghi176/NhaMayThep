using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.PhongBan.GetByPagination
{
    public class GetPhongBanByPaginationQueryHandler : IRequestHandler<GetPhongBanByPaginationQuery, PagedResult<PhongBanDto>>
    {
        private readonly IPhongBanRepository _phongBanRepository;
        private readonly IMapper _mapper;
        public GetPhongBanByPaginationQueryHandler(IPhongBanRepository phongBanRepository, IMapper mapper)
        {
            _phongBanRepository = phongBanRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<PhongBanDto>> Handle(GetPhongBanByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _phongBanRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<PhongBanDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToPhongBanDtoList(_mapper)
                );
        }
    }
}
