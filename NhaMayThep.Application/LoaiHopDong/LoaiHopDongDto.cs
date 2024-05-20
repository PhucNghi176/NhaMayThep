using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.LoaiHopDong
{
    public class LoaiHopDongDto : IMapFrom<LoaiHopDongEntity>
    {
        public LoaiHopDongDto() { }
        public static LoaiHopDongDto Create(int id, string tenHopDong)
        {
            return new LoaiHopDongDto()
            {
                Id = id,
                Name = tenHopDong
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoaiHopDongEntity, LoaiHopDongDto>();
        }
    }
}
