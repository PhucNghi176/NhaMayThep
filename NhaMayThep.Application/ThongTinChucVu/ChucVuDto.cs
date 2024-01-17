using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.ThongTinChucVu
{
    public class ChucVuDto : IMapFrom<ThongTinChucVuEntity>
    {
        public ChucVuDto() { }
        public static ChucVuDto Create(int id, string name)
        {
            return new ChucVuDto()
            {
                Name = name,
            };
        }

        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinChucVuEntity, ChucVuDto>();
        }
    }
}
