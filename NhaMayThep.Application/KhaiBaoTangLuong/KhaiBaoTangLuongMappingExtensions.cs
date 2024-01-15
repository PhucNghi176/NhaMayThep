using AutoMapper;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong
{
    public static class KhaiBaoTangLuongMappingExtensions
    {
        public static KhaiBaoTangLuongDto MapToKhaiBaoTangLuongDto(this KhaiBaoTangLuongEntity k, IMapper mapper)
        => mapper.Map<KhaiBaoTangLuongDto>(k);

        public static List<KhaiBaoTangLuongDto> MapToKhaiBaoTangLuongDtoList(this IEnumerable<KhaiBaoTangLuongEntity> ks, IMapper mapper)
        => ks.Select(x => x.MapToKhaiBaoTangLuongDto(mapper)).ToList();
    }
}
