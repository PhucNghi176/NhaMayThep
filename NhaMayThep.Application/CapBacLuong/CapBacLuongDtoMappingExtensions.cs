using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CapBacLuong
{
    public static class CapBacLuongDtoMappingExtensions
    {
        public static CapBacLuongDto MapToCapBacLuongDto(this CapBacLuongEntity capBacLuong, IMapper mapper)
            => mapper.Map<CapBacLuongDto>(capBacLuong);

        public static List<CapBacLuongDto> MapToCapBacLuongDtoList(this IEnumerable<CapBacLuongEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToCapBacLuongDto(mapper)).ToList();
    }
}
