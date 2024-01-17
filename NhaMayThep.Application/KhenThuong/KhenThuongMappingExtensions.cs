using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.KhaiBaoTangLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong
{
    public static class KhenThuongMappingExtensions
    {
        public static KhenThuongDto MapToKhenThuongDto(this KhenThuongEntity k, IMapper mapper)
        => mapper.Map<KhenThuongDto>(k);

        public static List<KhenThuongDto> MapToKhenThuongDtoList(this IEnumerable<KhenThuongEntity> ks, IMapper mapper)
        => ks.Select(x => x.MapToKhenThuongDto(mapper)).ToList();
    }
}
