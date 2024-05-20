using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.CapBacLuong
{
    public class CapBacLuongDto : IMapFrom<CapBacLuongEntity>
    {
        public CapBacLuongDto() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public float HeSoLuong { get; set; }
        public string TrinhDo { get; set; }
        public static CapBacLuongDto CreateCapBacLuong(int id, string name, float heSoLuong, string trinhDo)
        {
            return new CapBacLuongDto()
            {
                Id = id,
                Name = name,
                HeSoLuong = heSoLuong,
                TrinhDo = trinhDo
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CapBacLuongEntity, CapBacLuongDto>();
        }
    }
}
