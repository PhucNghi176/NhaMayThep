using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.FilterByChucVu
{
    public class FilterByChucVuQuery : IRequest<PagedResult<NhanVienDto>>, IQuery
    {
        public int pageNumber {  get; set; }
        public int pageSize { get; set; }
        public int chucvuID {  get; set; }
        public FilterByChucVuQuery(int chucvuID, int pageNumber, int pageSize)
        {
            this.chucvuID = chucvuID;
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
        }
        public FilterByChucVuQuery() { }
    }
}
