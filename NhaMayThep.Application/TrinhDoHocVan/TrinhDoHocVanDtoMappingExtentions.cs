using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.TrinhDoHocVan
{
    public static class TrinhDoHocVanDtoMappingExtensions
    {
        public static TrinhDoHocVanDto MapToTrinhDoHocVanDto(this TrinhDoHocVanEntity entity, IMapper mapper)
            => mapper.Map<TrinhDoHocVanDto>(entity);

        public static List<TrinhDoHocVanDto> MapToTrinhDoHocVanDtoList(this IEnumerable<TrinhDoHocVanEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToTrinhDoHocVanDto(mapper)).ToList();
    }
}
