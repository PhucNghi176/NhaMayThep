using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.NhanVien.FilterByHotenNhanVienOrEmailNhanVien
{
    public class FilterByHotenNhanVienOrEmailNhanVienQuery : IRequest<PagedResult<NhanVienDto>>, IQuery
    {

        public string HoTenHoacEmail { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public FilterByHotenNhanVienOrEmailNhanVienQuery(string HoTenHoacEmail, int pageSize, int pageNumber)
        {
            this.HoTenHoacEmail = HoTenHoacEmail;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public FilterByHotenNhanVienOrEmailNhanVienQuery() { }
    }
}
