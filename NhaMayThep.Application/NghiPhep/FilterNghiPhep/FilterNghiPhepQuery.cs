using MediatR;
using NhaMapThep.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NghiPhep.FilterNghiPhep
{
    public class FilterNghiPhepQuery : IRequest<PagedResult<NghiPhepDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? MaSoNhanVien { get; set; }
        public int? LoaiNghiPhepID { get; set; }

        public FilterNghiPhepQuery() { }

        public FilterNghiPhepQuery(int pageNumber, int pageSize, string maSoNhanVien, int? loaiNghiPhepID)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            MaSoNhanVien = maSoNhanVien;
            LoaiNghiPhepID = loaiNghiPhepID;
        }
    }
}
