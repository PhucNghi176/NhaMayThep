using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
