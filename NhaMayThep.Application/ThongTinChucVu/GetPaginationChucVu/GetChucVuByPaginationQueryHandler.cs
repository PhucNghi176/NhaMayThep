using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinChucVu.GetPaginationChucVu
{
    public class GetChucVuByPaginationQueryHandler : IRequestHandler<GetChucVuByPaginationQuery, PagedResult<ChucVuDto>>
    {
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IMapper _mapper;
        public GetChucVuByPaginationQueryHandler(IChucVuRepository chucVuRepository, IMapper mapper)
        {
            _chucVuRepository = chucVuRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ChucVuDto>> Handle(GetChucVuByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _chucVuRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<ChucVuDto>.Create(
                    totalCount: list.TotalCount,
                    pageCount: list.PageCount,
                    pageSize: list.PageSize,
                    pageNumber: list.PageNo,
                    data: list.MapToChucVuDtoList(_mapper)
                    );
        }
    }
}
