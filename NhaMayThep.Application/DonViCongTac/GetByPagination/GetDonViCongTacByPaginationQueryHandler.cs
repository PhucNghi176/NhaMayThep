using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.DonViCongTac.GetByPagination
{
    public class GetDonViCongTacByPaginationQueryHandler : IRequestHandler<GetDonVICongTacByPaginationQuery, PagedResult<DonViCongTacDto>>
    {
        private readonly IDonViCongTacRepository _donViCongTacRepository;
        private readonly IMapper _mapper;
        public GetDonViCongTacByPaginationQueryHandler(IDonViCongTacRepository donViCongTacRepository, IMapper mapper)
        {
            _donViCongTacRepository = donViCongTacRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<DonViCongTacDto>> Handle(GetDonVICongTacByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _donViCongTacRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<DonViCongTacDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToDonViCongTacDtoList(_mapper)
                );
        }
    }
}
