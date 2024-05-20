using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.ThongTinChucVuDang
{
    public class ThongTinChucVuDangDto : IMapFrom<ThongTinChucVuDangEntity>
    {
        public ThongTinChucVuDangDto() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public static ThongTinChucVuDangDto CreateThongTinChucVuDang(int id, string name)
        {
            return new ThongTinChucVuDangDto()
            {
                Id = id,
                Name = name
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinChucVuDangEntity, ThongTinChucVuDangDto>();
        }
    }
}
