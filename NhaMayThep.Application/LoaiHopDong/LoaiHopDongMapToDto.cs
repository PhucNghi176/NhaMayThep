using AutoMapper;

namespace NhaMayThep.Application.LoaiHopDong
{
    public static class LoaiHopDongMapToDto
    {
        public static LoaiHopDongDto MapToLoaiHopDongDto(this NhaMapThep.Domain.Entities.ConfigTable.LoaiHopDongEntity loaiHopDong, IMapper mapper)
            => mapper.Map<LoaiHopDongDto>(loaiHopDong);
    }
}
