using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap
{
    public class ThongTinPhuCapDTO : IMapFrom<ThongTinPhuCapEntity>
    {
        public int id {  get; set; }
        public string name { get; set; }
        public decimal SoTienPhuCap { get; set; }
        public ThongTinPhuCapDTO() { }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinPhuCapEntity, ThongTinPhuCapDTO>();
        }
    }
}
