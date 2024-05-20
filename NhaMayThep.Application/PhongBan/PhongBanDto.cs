using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.PhongBan
{
    public class PhongBanDto : IMapFrom<PhongBanEntity>
    {
        public PhongBanDto()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PhongBanEntity, PhongBanDto>();
        }
    }
}
