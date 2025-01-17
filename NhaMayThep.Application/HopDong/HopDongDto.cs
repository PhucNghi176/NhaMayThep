﻿using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.HopDong
{
    public class HopDongDto : IMapFrom<HopDongEntity>
    {
        public HopDongDto() { }

        public static HopDongDto Create(string id, string NhanVienID, int loaiHopDongId, DateTime ngayKyHopDong, DateTime ngayKetThucHopDong
                                                        , int thoiHanHopDong, string diaDiemLamViec, string boPhanLamViec, int chucDanhId
                                                        , int chucVuId, decimal luongCoBan, int heSoLuongId, string phuCapId
                                                        , string ghiChu, string loaiHopDong, string tenNhanVien, string chucDanh, string chucVu, string phuCap)
        {
            return new HopDongDto()
            {
                ID = id,
                NhanVienID = NhanVienID,
                LoaiHopDong = loaiHopDong,
                TenNhanVien = tenNhanVien,
                ChucDanh = chucDanh,
                ChucVu = chucVu,
                PhuCap = phuCap,
                LoaiHopDongId = loaiHopDongId,
                NgayKy = ngayKyHopDong,
                NgayKetThuc = ngayKetThucHopDong,
                ThoiHanHopDong = thoiHanHopDong,
                DiaDiemLamViec = diaDiemLamViec,
                BoPhanLamViec = boPhanLamViec,
                ChucDanhID = chucDanhId,
                ChucVuID = chucVuId,
                LuongCoBan = luongCoBan,
                HeSoLuongID = heSoLuongId,
                PhuCapID = phuCapId,
                GhiChu = ghiChu
            };
        }
        public string LoaiHopDong { get; set; }
        public string TenNhanVien { get; set; }
        public string ChucDanh { get; set; }
        public string ChucVu { get; set; }
        public string PhuCap { get; set; }
        //public string HeSoLuong { get; set; }
        public string ID { get; set; }
        public string NhanVienID { get; set; }
        public int LoaiHopDongId { get; set; }
        public DateTime NgayKy { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int ThoiHanHopDong { get; set; }
        public string DiaDiemLamViec { get; set; }
        public string BoPhanLamViec { get; set; }
        public int ChucDanhID { get; set; }
        public int ChucVuID { get; set; }
        public decimal LuongCoBan { get; set; }
        public int HeSoLuongID { get; set; }
        public string PhuCapID { get; set; }
        public string GhiChu { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HopDongEntity, HopDongDto>();
        }
    }
}
