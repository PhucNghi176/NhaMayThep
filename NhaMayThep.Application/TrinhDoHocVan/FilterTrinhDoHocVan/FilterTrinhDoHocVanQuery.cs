using MediatR;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.TrinhDoHocVan.FilterTrinhDoHocVan
{
    public class FilterTrinhDoHocVanQuery : IRequest<PagedResult<TrinhDoHocVanDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string TenTrinhDo { get; set; }

        public FilterTrinhDoHocVanQuery() { }

        public FilterTrinhDoHocVanQuery(int pageNumber, int pageSize, string tenTrinhDo)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TenTrinhDo = tenTrinhDo;
        }
    }
}
