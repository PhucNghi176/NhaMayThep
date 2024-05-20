using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.ThongTinCapDangVien
{
    public class ThongTinCapDangVienDto : IMapFrom<ThongTinCapDangVienEntity>
    {
        public ThongTinCapDangVienDto() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public static ThongTinCapDangVienDto CreateThongTinCapDangVien(int id, string name)
        {
            return new ThongTinCapDangVienDto()
            {
                Id = id,
                Name = name
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinCapDangVienEntity, ThongTinCapDangVienDto>();
        }
    }
}
