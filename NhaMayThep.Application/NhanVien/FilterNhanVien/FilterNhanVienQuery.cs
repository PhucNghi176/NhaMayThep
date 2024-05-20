using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.NhanVien.FilterNhanVien
{
    public class FilterNhanVienQuery : IRequest<PagedResult<NhanVienDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? chucvuID { get; set; } = 0;
        public int? tinhtranglamviecID { get; set; } = 0;
        public string? Email { get; set; }
        public string? HoVaTen { get; set; }

        public string? CanCuocCongDan { get; set; }

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
