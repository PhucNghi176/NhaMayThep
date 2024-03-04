using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.ThongTinChucDanh
{
    public static class ChucDanhMapToDto
    {
        public static ChucDanhDto MapToChucDanhDto(this NhaMapThep.Domain.Entities.ConfigTable.ThongTinChucDanhEntity entity, IMapper mapper)
            => mapper.Map<ChucDanhDto>(entity);
        public static List<ChucDanhDto> MapToListChucDanhDto(this IEnumerable<ThongTinChucDanhEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToChucDanhDto(mapper)).ToList();
    }
}
