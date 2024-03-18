using MediatR;
using NhaMapThep.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiem.FilterBaoHiem
{
    public class FilterBaoHiemQuery : IRequest<PagedResult<BaoHiemDto>>, IRequest
    {
        public FilterBaoHiemQuery() { }
        public FilterBaoHiemQuery(
            int pagenumber,
            int pagesize,
            int id,
            string? name,
            double discount)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
            Id = id;
            Name = name;
            Discount = discount;    
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }   
        public int Id { get; set; }
        public string? Name { get; set; }    
        public double Discount { get; set; }
    }
}
