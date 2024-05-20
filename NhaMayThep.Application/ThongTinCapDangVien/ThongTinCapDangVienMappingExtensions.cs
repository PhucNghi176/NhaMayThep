using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.ThongTinCapDangVien
{
    public static class ThongTinCapDangVienDtoMappingExtensions
    {
        public static ThongTinCapDangVienDto MapToThongTinCapDangVienDto(this ThongTinCapDangVienEntity thongTinCapDangVien, IMapper mapper)
            => mapper.Map<ThongTinCapDangVienDto>(thongTinCapDangVien);

        public static List<ThongTinCapDangVienDto> MapToThongTinCapDangVienDtoList(this IEnumerable<ThongTinCapDangVienEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToThongTinCapDangVienDto(mapper)).ToList();
    }
}
