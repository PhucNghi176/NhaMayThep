using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.NhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HopDong.FilterHopDong
{
    public class FilterHopDongQuery : IRequest<PagedResult<HopDongDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? LoaiHopDongID { get; set; } = 0;
        public  DateTime? NgayKy { get; set; }
        public string BoPhanLamViec { get; set; }
        public int? ChucVuID { get; set; } = 0;
        public int? ChucDanhID { get; set; } = 0;
        public string PhuCapID { get; set; }

        public FilterHopDongQuery() { }

        public FilterHopDongQuery(int pageNumber, int pageSize, int? loaiHopDongID, DateTime? ngayKy, string? bophanlamviec, int? chucVuID, int? chucDanhID, string phuCapID)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            LoaiHopDongID = loaiHopDongID;
            NgayKy = ngayKy;
            BoPhanLamViec = bophanlamviec;
            ChucVuID = chucVuID;
            ChucDanhID = chucDanhID;
            PhuCapID = phuCapID;
        }
    }
}
