using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.DonViCongTac
{
    public class DonViCongTacDto : IMapFrom<DonViCongTacEntity>
    {
        public DonViCongTacDto()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public static DonViCongTacDto Create(int id, string name)
        {
            return new DonViCongTacDto
            {
                ID = id,
                Name = name
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DonViCongTacEntity, DonViCongTacDto>();
        }
    }
}
