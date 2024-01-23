using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;

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
