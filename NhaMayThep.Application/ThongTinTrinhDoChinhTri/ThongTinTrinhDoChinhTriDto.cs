using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri
{
    public class ThongTinTrinhDoChinhTriDto : IMapFrom<ThongTinTrinhDoChinhTriEntity>
    {
        public ThongTinTrinhDoChinhTriDto() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public static ThongTinTrinhDoChinhTriDto CreateThongTinTrinhDoChinhTri(int id, string name)
        {
            return new ThongTinTrinhDoChinhTriDto()
            {
                Id = id,
                Name = name
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinTrinhDoChinhTriEntity, ThongTinTrinhDoChinhTriDto>();
        }
    }
}
