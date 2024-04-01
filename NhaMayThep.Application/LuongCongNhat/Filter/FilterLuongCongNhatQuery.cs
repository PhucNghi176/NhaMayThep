using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int PageNo {  get; set; }
        public int PageSize {  get; set; }
        public string? MaSoNhanVien {  get; set; }
        public decimal? Luong1Gio {  get; set; }
        public double? SoGioLam {  get; set; }
    }
}
