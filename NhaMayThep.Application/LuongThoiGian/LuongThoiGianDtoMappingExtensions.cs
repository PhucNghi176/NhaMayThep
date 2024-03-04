using AutoMapper;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongThoiGian
{
    public static class LuongThoiGianDtoMappingExtensions
    {
        public static LuongThoiGianDto MapToLuongThoiGianDto(this LuongThoiGianEntity entity, IMapper mapper)
            => mapper.Map<LuongThoiGianDto>(entity);

        public static List<LuongThoiGianDto> MapToLuongThoiGianDtoList(this IEnumerable<LuongThoiGianEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToLuongThoiGianDto(mapper)).ToList();
    }
}
