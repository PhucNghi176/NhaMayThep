using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHopDong
{
    public class LoaiHopDongDto : IMapFrom<LoaiHopDongEntity>
    {
        public LoaiHopDongDto() { }
        public static LoaiHopDongDto Create(int id, string tenHopDong)
        {
            return new LoaiHopDongDto()
            {
                ID = id,
                Name = tenHopDong
            };
        }

        public int ID { get; set; }
        public string Name {  get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoaiHopDongEntity, LoaiHopDongDto>();
        }
    }
}
