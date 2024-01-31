using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CanCuocCongDan.GetPagination
{
    public class GetCCCDByPaginationQueryHandler : IRequestHandler<GetCCCDByPaginationQuery, PagedResult<CanCuocCongDanDto>>
    {
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;
        private readonly IMapper _mapper;
        public GetCCCDByPaginationQueryHandler(ICanCuocCongDanRepository canCuocCongDanRepository, IMapper mapper)
        {
            _canCuocCongDanRepository = canCuocCongDanRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<CanCuocCongDanDto>> Handle(GetCCCDByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _canCuocCongDanRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<CanCuocCongDanDto>.Create(
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToListCCCDDto(_mapper)
                );
        }
    }
}
