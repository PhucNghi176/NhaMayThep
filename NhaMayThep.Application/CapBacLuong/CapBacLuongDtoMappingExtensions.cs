using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.CapBacLuong
{
    public static class CapBacLuongDtoMappingExtensions
    {
        public static CapBacLuongDto MapToCapBacLuongDto(this CapBacLuongEntity capBacLuong, IMapper mapper)
            => mapper.Map<CapBacLuongDto>(capBacLuong);

        public static List<CapBacLuongDto> MapToCapBacLuongDtoList(this IEnumerable<CapBacLuongEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToCapBacLuongDto(mapper)).ToList();
    }
}
