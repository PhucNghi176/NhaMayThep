using MediatR;
using NhaMapThep.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.FilterThongTinGiamTruGiaCanh
{
    public class FilterThongTinGiamTruGiaCanhQueryHandler : IRequestHandler<FilterThongTinGiamTruGiaCanhQuery, PagedResult<ThongTinGiamTruGiaCanhDto>>
    {
        public Task<PagedResult<ThongTinGiamTruGiaCanhDto>> Handle(FilterThongTinGiamTruGiaCanhQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
