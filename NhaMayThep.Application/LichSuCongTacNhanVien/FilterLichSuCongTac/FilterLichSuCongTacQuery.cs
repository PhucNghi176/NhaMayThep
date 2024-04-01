using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.FilterLichSuCongTac
{
    public class FilterLichSuCongTacQuery : IRequest<PagedResult<LichSuCongTacNhanVienDto>>, IQuery
    {
        public FilterLichSuCongTacQuery() { }

        public FilterLichSuCongTacQuery(int pageSize, int pageNumber) 
        { 
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public FilterLichSuCongTacQuery(int pageNumber, int pageSize, string? maSoNhanVien, string? loaiCongTac, DateTime? ngayBatDau, DateTime? ngayKetThuc, string? noiCongTac) : this(pageNumber, pageSize)
        {
            MaSoNhanVien = maSoNhanVien;
            LoaiCongTac = loaiCongTac;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            NoiCongTac = noiCongTac;
        }

        public int PageNumber {  get; set; }
        public int PageSize { get; set; }
        public string? MaSoNhanVien {  get; set; }
        public string? HoVaTen {  get; set; }
        public string? LoaiCongTac {  get; set; }
        public DateTime? NgayBatDau {  get; set; }
        public DateTime? NgayKetThuc {  get; set; }
        public string? NoiCongTac {  get; set; }
    }
}
