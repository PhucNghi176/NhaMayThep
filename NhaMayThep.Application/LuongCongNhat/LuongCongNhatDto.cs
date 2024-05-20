using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.LuongCongNhat
{
    public class LuongCongNhatDto : IMapFrom<LuongCongNhatEntity>
    {
        public LuongCongNhatDto()
        {
        }

        public string ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public double SoGioLam { get; set; }

        public decimal Luong1Gio { get; set; }

        public decimal TongLuong { get; set; }

        public DateTime NgayKhaiBao { get; set; }

        public static LuongCongNhatDto Create(string id, string maSoNhanVien, double soGioLam, decimal luong1Gio, decimal tongLuong, DateTime ngayKhaiBao)
        {
            return new LuongCongNhatDto
            {
                ID = id,
                MaSoNhanVien = maSoNhanVien,
                SoGioLam = soGioLam,
                Luong1Gio = luong1Gio,
                TongLuong = tongLuong,
                NgayKhaiBao = ngayKhaiBao
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LuongCongNhatEntity, LuongCongNhatDto>();
        }
    }
}
