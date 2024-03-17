using AutoMapper;
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
        public string? MaSoNhanVien { get; set; }
        public string NhanVien { get; set; } = null!;
        public int LoaiBaoHiem { get; set; }
        public string BaoHiem { get; set; } = null!;
        public string? PhanTramBaoHiem { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string? NoiCap { get; set; }
        public static ChiTietBaoHiemDto CreateChiTietBaoHiem(string id, string nhanvien, string baohiem, DateTime ngayheuluc, DateTime ngayketthuc
            ,string noicap, string masonhanvien, int loaibaohiem, string phantrambaohiem)
        {
            return new ChiTietBaoHiemDto
            {
                Id = id,
                NhanVien = nhanvien,
                BaoHiem = baohiem,
                NgayHieuLuc = ngayheuluc,
                NgayKetThuc = ngayketthuc,
                NoiCap = noicap,
                MaSoNhanVien= masonhanvien,
                LoaiBaoHiem= loaibaohiem,
                PhanTramBaoHiem = phantrambaohiem
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChiTietBaoHiemEntity, ChiTietBaoHiemDto>();
        }
    }
}
