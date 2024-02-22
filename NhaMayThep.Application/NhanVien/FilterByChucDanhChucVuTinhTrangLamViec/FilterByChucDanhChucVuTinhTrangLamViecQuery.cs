using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.FilterByChucDanhChucVuTinhTrangLamViec
{
    public class FilterByChucDanhChucVuTinhTrangLamViecQuery : IRequest<PagedResult<NhanVienDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string ChucVuHoacTinhTrangLamViec {  get; set; }
        public FilterByChucDanhChucVuTinhTrangLamViecQuery(string ChucVuHoacTinhTrangLamViec, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.ChucVuHoacTinhTrangLamViec = ChucVuHoacTinhTrangLamViec;
        }
        public FilterByChucDanhChucVuTinhTrangLamViecQuery() { }
    }
}
