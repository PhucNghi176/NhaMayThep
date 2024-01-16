using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.KhaiBaoTangLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu
{
    public static class ChinhSachNhanSuMappingExtensions
    {
        public static ChinhSachNhanSuDto MapToChinhSachNhanSuDto(this ChinhSachNhanSuEntity k, IMapper mapper)
        => mapper.Map<ChinhSachNhanSuDto>(k);

        public static List<ChinhSachNhanSuDto> MapToChinhSachNhanSuDtoList(this IEnumerable<ChinhSachNhanSuEntity> ks, IMapper mapper)
        => ks.Select(x => x.MapToChinhSachNhanSuDto(mapper)).ToList();
    }
}
