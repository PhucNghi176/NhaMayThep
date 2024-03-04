using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.FillterByChucVuIDOrTinhTrangLamViecID
{
    public class FilterNhanVienQuery : IRequest<PagedResult<NhanVienDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? chucvuID { get; set; } = 0;
        public int? tinhtranglamviecID { get; set; } = 0;
        public string? Email { get; set; }
        public string? HoVaTen { get; set; }
        
        public string? CanCuocCongDan {  get; set; }

        public FilterNhanVienQuery() { }
        public FilterNhanVienQuery(int no, int pageSize, int chucvuID, int tinhtranglamviecID, string email, string hoVaTen, string? canCuocCongDan)
        {
            PageNumber = no;
            PageSize = pageSize;
            this.chucvuID = chucvuID;
            this.tinhtranglamviecID = tinhtranglamviecID;
            Email = email;
            HoVaTen = hoVaTen;
            CanCuocCongDan = canCuocCongDan;
        }
    }
}
