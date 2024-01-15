using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru
{
    public class ThongTinGiamTruDTO
    {
        public int Id { get; set; }
        public string TenMaGiamTru { get; set; }
        public decimal SoTienGiamTru { get; set; }
        public ThongTinGiamTruDTO() { }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinGiamTruEntity,ThongTinGiamTruDTO>();
        }
    }
}
