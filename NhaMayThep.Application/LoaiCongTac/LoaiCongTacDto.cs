using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.LoaiCongTac
{
    public class LoaiCongTacDto : IMapFrom<LoaiCongTacEntity>
    {

        public LoaiCongTacDto() { }

        public static LoaiCongTacDto Create(int id, string name)
        {
            return new LoaiCongTacDto
            {
                Id = id,
                Name = name,
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoaiCongTacEntity, LoaiCongTacDto>();
        }
    }
}
