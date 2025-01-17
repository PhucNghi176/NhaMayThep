﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.HopDong.FilterHopDong
{
    public class FilterHopDongQuery : IRequest<PagedResult<HopDongDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? LoaiHopDongID { get; set; } = 0;
        public DateTime? NgayKy { get; set; }
        public string? BoPhanLamViec { get; set; }
        public int? ChucVuID { get; set; } = 0;
        public int? ChucDanhID { get; set; } = 0;
        public string? PhuCapID { get; set; }

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
