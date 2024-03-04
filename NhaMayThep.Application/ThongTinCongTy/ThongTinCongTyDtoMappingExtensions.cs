using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.ThongTinCongTy
{
    public static class ThongTinCongTyDtoMappingExtensions
    {
        public static ThongTinCongTyDto MapToThongTinCongTyDto(this ThongTinCongTyEntity entity, IMapper mapper)
          => mapper.Map<ThongTinCongTyDto>(entity);

        public static List<ThongTinCongTyDto> MapToThongTinCongTyDtoList(this IEnumerable<ThongTinCongTyEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToThongTinCongTyDto(mapper)).ToList();
    }
}
