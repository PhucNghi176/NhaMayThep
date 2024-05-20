using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.LoaiHopDong.GetByPagination
{
    public class GetLoaiHopDongByPaginationQueryHandler : IRequestHandler<GetLoaiHopDongByPaginationQuery, PagedResult<LoaiHopDongDto>>
    {
        private readonly ILoaiHopDongReposity _loaiHopDongReposity;
        private readonly IMapper _mapper;
        public GetLoaiHopDongByPaginationQueryHandler(ILoaiHopDongReposity loaiHopDongReposity, IMapper mapper)
        {
            _loaiHopDongReposity = loaiHopDongReposity;
            _mapper = mapper;
        }
        public async Task<PagedResult<LoaiHopDongDto>> Handle(GetLoaiHopDongByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _loaiHopDongReposity.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<LoaiHopDongDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToListLoaiHopDongDto(_mapper)
                );
        }
    }
}
