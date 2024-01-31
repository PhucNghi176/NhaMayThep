using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.HopDong
{
    public static class HopDongMapToDto
    {
        public static HopDongDto MapToHopDongDto(this NhaMapThep.Domain.Entities.HopDongEntity hopDong, IMapper mapper)
            => mapper.Map<HopDongDto>(hopDong);
        public static List<HopDongDto> MapToListDto(this IEnumerable<HopDongEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToHopDongDto(mapper)).ToList();
    }
}
