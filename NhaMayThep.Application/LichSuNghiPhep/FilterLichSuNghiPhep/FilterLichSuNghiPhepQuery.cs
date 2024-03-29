using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.Filter
{
    public class FilterLichSuNghiPhepQuery : IRequest<PagedResult<LichSuNghiPhepDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? MaSoNhanVien { get; set; }
        public int? LoaiNghiPhepID { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string? NguoiDuyet { get; set; }
        public string? LyDo { get; set; }
        public string? TenNguoiDuyet { get; set; }
        public string? TenNhanVien { get; set; }
        public string? TenLoaiNghiPhep { get; set; }

    }
}