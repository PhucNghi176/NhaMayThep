using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep
{
    public class LoaiNghiPhepDto : IMapFrom<LoaiNghiPhepEntity>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SoGioNghiPhep { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoaiNghiPhepEntity, LoaiNghiPhepDto>();
        }
    }
}
