﻿using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem
{
    public class BaoHiemNhanVienChiTietBaoHiemDto : IMapFrom<BaoHiemNhanVienBaoHiemChiTietEntity>
    {
        public required int MaBaoHiemNhanVien { get; set; }
        public string? MaNhanVien { get; set; }
        public string? TenNhanVien { get; set; }
        public required string MaChiTietBaoHiem { get; set; }
        public int? LoaiBaoHiem { get; set; }
        public double? PhanTramKhauTru { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string? NoiCap { get; set; }
        public static BaoHiemNhanVienChiTietBaoHiemDto CreateMapper(int mabaohiemnhanvien,
            string? manhanvien,
            string? tennhanvien,
            string machitietbaohiem,
            int? loaibaohiem,
            double? phantramkhautru,
            DateTime? ngayhieuluc,
            DateTime? ngayketthuc,
            string? noicap)
        {
            return new BaoHiemNhanVienChiTietBaoHiemDto
            {
                MaBaoHiemNhanVien = mabaohiemnhanvien,
                MaNhanVien = manhanvien,
                TenNhanVien = tennhanvien,
                MaChiTietBaoHiem = machitietbaohiem,
                LoaiBaoHiem = loaibaohiem,
                NgayHieuLuc = ngayhieuluc,
                NgayKetThuc = ngayketthuc,
                NoiCap = noicap,
                PhanTramKhauTru = phantramkhautru
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BaoHiemNhanVienBaoHiemChiTietEntity, BaoHiemNhanVienChiTietBaoHiemDto>();
        }
    }
}
