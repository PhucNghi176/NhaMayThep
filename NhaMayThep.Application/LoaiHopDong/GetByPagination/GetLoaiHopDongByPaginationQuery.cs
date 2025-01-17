﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.LoaiHopDong.GetByPagination
{
    public class GetLoaiHopDongByPaginationQuery : IRequest<PagedResult<LoaiHopDongDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetLoaiHopDongByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetLoaiHopDongByPaginationQuery() { }
    }
}
