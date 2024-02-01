using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MucSanPham.GetByPagination
{
    public class GetMucSanPhamByPaginationQueryHandler : IRequestHandler<GetMucSanPhamByPaginationQuery, PagedResult<MucSanPhamDto>>
    {
        private readonly IMucSanPhamRepository _mucSanPhamRepository;
        private readonly IMapper _mapper;
        public GetMucSanPhamByPaginationQueryHandler(IMucSanPhamRepository mucSanPhamRepository, IMapper mapper)
        {
            _mucSanPhamRepository = mucSanPhamRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<MucSanPhamDto>> Handle(GetMucSanPhamByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _mucSanPhamRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<MucSanPhamDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToMucSanPhamDtoList(_mapper)
                );
        }
    }
}
