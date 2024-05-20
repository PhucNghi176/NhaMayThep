using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.BaoHiem.GetPaginationBaoHiem
{
    public class GetBaoHiemByPaginationHandler : IRequestHandler<GetBaoHiemByPagination, PagedResult<BaoHiemDto>>
    {
        private readonly IBaoHiemRepository _baoHiemRepository;
        private readonly IMapper _mapper;
        public GetBaoHiemByPaginationHandler(IBaoHiemRepository baoHiemRepository, IMapper mapper)
        {
            _baoHiemRepository = baoHiemRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BaoHiemDto>> Handle(GetBaoHiemByPagination query, CancellationToken cancellationToken)
        {
            var list = await _baoHiemRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<BaoHiemDto>.Create(
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToListBaoHiemDto(_mapper)
                );
        }
    }
}
