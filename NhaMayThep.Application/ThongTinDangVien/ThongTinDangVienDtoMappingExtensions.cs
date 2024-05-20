using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.ThongTinDangVien
{
    public static class ThongTinDangVienDtoMappingExtensions
    {
        public static ThongTinDangVienDto MapToThongTinDangVienDto(this ThongTinDangVienEntity projectFrom, IMapper mapper)
            => mapper.Map<ThongTinDangVienDto>(projectFrom);

        public static List<ThongTinDangVienDto> MapToThongTinDangVienDtoList(this IEnumerable<ThongTinDangVienEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToThongTinDangVienDto(mapper)).ToList();
    }
}
