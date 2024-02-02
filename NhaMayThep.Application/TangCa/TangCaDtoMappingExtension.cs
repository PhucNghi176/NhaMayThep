using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.TangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TangCa
{
    public static class TangCaMappingExtension
    {
        public static TangCaDto MapToTangCaDto(this TangCaEntity projectFrom, IMapper mapper)
            => mapper.Map<TangCaDto>(projectFrom);

        public static List<TangCaDto> MapToTangCaDtoList(this IEnumerable<TangCaEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToTangCaDto(mapper)).ToList();
    }
}
