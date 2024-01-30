using AutoMapper;

namespace NhaMayThep.Application.HopDong
{
    public static class HopDongMapToDto
    {
        public static HopDongDto MapToHopDongDto(this NhaMapThep.Domain.Entities.HopDongEntity hopDong, IMapper mapper)
            => mapper.Map<HopDongDto>(hopDong);
    }
}
