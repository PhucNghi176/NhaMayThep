﻿using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.ChiTietBaoHiem
{
    public class ChiTietBaoHiemDto : IMapFrom<ChiTietBaoHiemEntity>
    {
        public string Id { get; set; } = null!;
        public int LoaiBaoHiem { get; set; }
        public string BaoHiem { get; set; } = null!;
        public string? PhanTramBaoHiem { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string? NoiCap { get; set; }
        public static ChiTietBaoHiemDto CreateChiTietBaoHiem(string id, string baohiem, DateTime ngayheuluc, DateTime ngayketthuc
            , string noicap, int loaibaohiem, string phantrambaohiem)
        {
            return new ChiTietBaoHiemDto
            {
                Id = id,
                BaoHiem = baohiem,
                NgayHieuLuc = ngayheuluc,
                NgayKetThuc = ngayketthuc,
                NoiCap = noicap,
                LoaiBaoHiem = loaibaohiem,
                PhanTramBaoHiem = phantrambaohiem
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChiTietBaoHiemEntity, ChiTietBaoHiemDto>();
        }
    }
}
