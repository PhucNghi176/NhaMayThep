using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap
{
    public class PhuCapDto : IMapFrom<ThongTinPhuCapEntity>
    {
        public PhuCapDto() { }
        
        public static PhuCapDto Create(int id, string name, double phanTram)
        {
            return new PhuCapDto()
            {
                ID = id,
                Name = name,
                PhanTramPhuCap = phanTram
            };
        }
        
        public int ID { get; set; }
        public string Name { get; set; }
        public double PhanTramPhuCap {  get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinPhuCapEntity, PhuCapDto>();
        }

    }
}
