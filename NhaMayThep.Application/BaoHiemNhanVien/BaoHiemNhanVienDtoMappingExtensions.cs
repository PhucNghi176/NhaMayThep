using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.BaoHiemNhanVien
{
    public static class BaoHiemNhanVienDtoMappingExtensions
    {
        public static BaoHiemNhanVienDto MapToBaoHiemNhanVienDto(this BaoHiemNhanVienEntity entity, IMapper mapper)
            => mapper.Map<BaoHiemNhanVienDto>(entity);

        public static List<BaoHiemNhanVienDto> MapToBaoHiemNhanVienDtoList(this IEnumerable<BaoHiemNhanVienEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToBaoHiemNhanVienDto(mapper)).ToList();
    }
}
