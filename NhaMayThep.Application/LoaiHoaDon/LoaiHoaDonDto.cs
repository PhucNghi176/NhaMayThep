using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHoaDon
{
    public class LoaiHoaDonDto : IMapFrom<LoaiHoaDonEntity>
    {
        public LoaiHoaDonDto() { }

        public static LoaiHoaDonDto create (int id,string name) 
        {
            return new LoaiHoaDonDto
            {
                Name = name,
            };
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoaiHoaDonEntity, LoaiHoaDonDto>();
        }
    }
}
