using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.LuongCongNhat.Filter
{
    public class FilterLuongCongNhatQuery : IRequest<PagedResult<LuongCongNhatDto>>, IQuery
    {
        public FilterLuongCongNhatQuery()
        {
        }

        public FilterLuongCongNhatQuery(int pageNo, int pageSize)
        {
            PageNo = pageNo;
            PageSize = pageSize;
        }

        public FilterLuongCongNhatQuery(int pageNo, int pageSize, string? maSoNhanVien, decimal? luong1Gio, double? soGioLam) : this(pageNo, pageSize)
        {
            MaSoNhanVien = maSoNhanVien;
            Luong1Gio = luong1Gio;
            SoGioLam = soGioLam;
        }

        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string? MaSoNhanVien { get; set; }
        public decimal? Luong1Gio { get; set; }
        public double? SoGioLam { get; set; }
    }
}
