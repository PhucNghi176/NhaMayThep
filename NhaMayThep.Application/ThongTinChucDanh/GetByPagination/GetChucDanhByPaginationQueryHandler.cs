using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinChucDanh.GetByPagination
{
    public class GetChucDanhByPaginationQueryHandler : IRequestHandler<GetChucDanhByPaginationQuery, PagedResult<ChucDanhDto>>
    {
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly IMapper _mapper;
        public GetChucDanhByPaginationQueryHandler(IChucDanhRepository chucDanhRepository, IMapper mapper)
        {
            _chucDanhRepository = chucDanhRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ChucDanhDto>> Handle(GetChucDanhByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _chucDanhRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<ChucDanhDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToListChucDanhDto(_mapper)
                );
        }
    }
}
