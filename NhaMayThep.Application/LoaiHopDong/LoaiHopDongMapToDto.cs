using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.LoaiHopDong
{
    public static class LoaiHopDongMapToDto
    {
        public static LoaiHopDongDto MapToLoaiHopDongDto(this NhaMapThep.Domain.Entities.ConfigTable.LoaiHopDongEntity loaiHopDong, IMapper mapper)
            => mapper.Map<LoaiHopDongDto>(loaiHopDong);
        public static List<LoaiHopDongDto> MapToListLoaiHopDongDto(this IEnumerable<LoaiHopDongEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToLoaiHopDongDto(mapper)).ToList();
    }
}
