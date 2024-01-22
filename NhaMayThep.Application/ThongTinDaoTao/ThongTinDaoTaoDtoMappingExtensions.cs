using AutoMapper;
using NhaMapThep.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NhaMayThep.Application.ThongTinDaoTao
{
    public static class ThongTinDaoTaoDtoMappingExtensions
    {
        public static ThongTinDaoTaoDto MapToThongTinDaoTaoDto(this ThongTinDaoTaoEntity entity, IMapper mapper)
            => mapper.Map<ThongTinDaoTaoDto>(entity);

        public static List<ThongTinDaoTaoDto> MapToThongTinDaoTaoDtoList(this IEnumerable<ThongTinDaoTaoEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToThongTinDaoTaoDto(mapper)).ToList();
    }
}
