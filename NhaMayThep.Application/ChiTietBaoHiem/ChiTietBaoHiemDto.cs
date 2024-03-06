﻿using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.ThongTinCongDoan;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem
{
    public class ChiTietBaoHiemDto : IMapFrom<ChiTietBaoHiemEntity>
    {
        public string Id { get; set; } = null!;
        public string NhanVien { get; set; } = null!;
        public string BaoHiem { get; set; } = null!;
        public string? NgayHieuLuc { get; set; }
        public string? NgayKetThuc { get; set; }
        public string? NoiCap { get; set; }
        public static ChiTietBaoHiemDto CreateChiTietBaoHiem(string id, string nhanvien, string baohiem, DateTime ngayheuluc, DateTime ngayketthuc
            ,string noicap)
        {
            return new ChiTietBaoHiemDto
            {
                Id = id,
                NhanVien = nhanvien,
                BaoHiem = baohiem,
                NgayHieuLuc = ngayheuluc.ToString("dd/MM/yyyy - HH:mm:ss"),
                NgayKetThuc = ngayketthuc.ToString("dd/MM/yyyy - HH:mm:ss"),
                NoiCap = noicap
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChiTietBaoHiemEntity, ChiTietBaoHiemDto>();
        }
    }
}