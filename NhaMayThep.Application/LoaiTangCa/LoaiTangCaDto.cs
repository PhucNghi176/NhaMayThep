using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.LoaiTangCa
{
    public class LoaiTangCaDto : IMapFrom<LoaiTangCaEntity>
    {
        public int ID { get; set; }
        public string Name { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoaiTangCaEntity, LoaiTangCaDto>();
        }
    }
}
