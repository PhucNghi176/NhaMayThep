using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.ThongTinLuongNhanVien
{
    public class ThongTinLuongNhanVienDTO : IMapFrom<ThongTinLuongNhanVienEntity>
    {
        public ThongTinLuongNhanVienDTO() { }

        public static ThongTinLuongNhanVienDTO Create(string Id, string MaSoNhanVien, string MaSoHopDong, string Loai, decimal LuongCu, decimal LuongMoi, DateTime NgayHieuLuc)
        {
            return new ThongTinLuongNhanVienDTO
            {
                Id = Id,
                MaSoNhanVien = MaSoNhanVien,
                MaSoHopDong = MaSoHopDong,
                Loai = Loai,
                LuongCu = LuongCu,
                LuongMoi = LuongMoi,
                NgayHieuLuc = NgayHieuLuc
            };
        }

        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public string MaSoHopDong { get; set; }
        public string Loai { get; set; }
        public decimal LuongCu { get; set; }
        public decimal LuongMoi { get; set; }
        public DateTime NgayHieuLuc { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinLuongNhanVienEntity, ThongTinLuongNhanVienDTO>();
        }
    }
}
