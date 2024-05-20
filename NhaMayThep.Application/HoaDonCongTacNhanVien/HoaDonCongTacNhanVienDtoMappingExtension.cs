using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien
{
    public static class HoaDonCongTacNhanVienDtoMappingExtension
    {
        public static HoaDonCongTacNhanVienDto MapToHoaDonCongTacNhanVienDto(this HoaDonCongTacNhanVienEntity projectFrom, IMapper mapper)
           => mapper.Map<HoaDonCongTacNhanVienDto>(projectFrom);

        public static List<HoaDonCongTacNhanVienDto> MapToHoaDonCongTacNhanVienDtoList(this IEnumerable<HoaDonCongTacNhanVienEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToHoaDonCongTacNhanVienDto(mapper)).ToList();
    }
}
