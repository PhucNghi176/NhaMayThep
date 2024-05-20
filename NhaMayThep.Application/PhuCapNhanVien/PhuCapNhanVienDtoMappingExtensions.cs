using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.PhuCapNhanVien
{
    public static class PhuCapNhanVienDtoMappingExtensions
    {
        public static PhuCapNhanVienDto MapToPhuCapNhanVienDto(this PhuCapNhanVienEntity entity, IMapper mapper)
            => mapper.Map<PhuCapNhanVienDto>(entity);

        public static List<PhuCapNhanVienDto> MapToPhuCapNhanVienDtoList(this IEnumerable<PhuCapNhanVienEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToPhuCapNhanVienDto(mapper)).ToList();
    }
}
