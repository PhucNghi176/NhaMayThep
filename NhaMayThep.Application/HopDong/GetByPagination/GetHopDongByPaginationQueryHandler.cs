using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HopDong.GetByPagination
{
    public class GetHopDongByPaginationQueryHandler : IRequestHandler<GetHopDongByPaginationQuery, PagedResult<HopDongDto>>
    {
        private readonly IHopDongRepository _hopDongRepository;
        private readonly IMapper _mapper;
        public GetHopDongByPaginationQueryHandler(IHopDongRepository hopDongRepository, IMapper mapper)
        {
            _hopDongRepository = hopDongRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<HopDongDto>> Handle(GetHopDongByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _hopDongRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<HopDongDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToListDto(_mapper)
                );
        }
    }
}
