using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.NhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru
{
    public class ThongTinGiamTruDTO : IMapFrom<ThongTinGiamTruEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SoTienGiamTru { get; set; }
        public ThongTinGiamTruDTO() { }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinGiamTruEntity,ThongTinGiamTruDTO>();
        }
        public static ThongTinGiamTruDTO Create(int id, string TenMaGiamTru, decimal SoTienGiamTru)
        {
            return new ThongTinGiamTruDTO
            {
                Id = id,
                Name = TenMaGiamTru,
                SoTienGiamTru = SoTienGiamTru,
            };
        }
    }
}
