using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien
{
    public class ThongTinLuongNhanVienDto : IMapFrom<ThongTinLuongNhanVienEntity>
    {

        public static ThongTinLuongNhanVienDto Create(Guid MaSoNhanVien, Guid MaSoHopDong, string Loai, decimal LuongCu, decimal LuongHienTai, DateTime NgayHieuLuc)
        {
            return new ThongTinLuongNhanVienDto
            {
                MaSoNhanVien = MaSoNhanVien,
                MaSoHopDong = MaSoHopDong,
                Loai = Loai,
                LuongCu = LuongCu,
                LuongHienTai = LuongHienTai,
                NgayHieuLuc = NgayHieuLuc
            };
        }
        public Guid MaSoNhanVien { get; set; }
        public Guid MaSoHopDong { get; set; }
        public string Loai { get; set; }
        public decimal LuongCu { get; set; }
        public decimal LuongHienTai { get; set; }
        public DateTime NgayHieuLuc { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinLuongNhanVienEntity, ThongTinLuongNhanVienDto>();
        }
    }
}
