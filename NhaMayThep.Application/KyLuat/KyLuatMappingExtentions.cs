using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.KhenThuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat
{
    public static class KyLuatMappingExtentions
    {
        public static KyLuatDto MapToKyLuatDto(this KyLuatEntity k, IMapper mapper)
        => mapper.Map<KyLuatDto>(k);

        public static List<KyLuatDto> MapToKyLuatDtoList(this IEnumerable<KyLuatEntity> ks, IMapper mapper)
        => ks.Select(x => x.MapToKyLuatDto(mapper)).ToList();
    }
}
