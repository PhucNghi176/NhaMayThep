using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.ThongTinDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThueTNCN
{
    public static class ThueTNCNDtoMappingExtensions
    {
        public static ThueTNCNDto MapToThueTNCNDto(this ThueTNCNEntity projectFrom, IMapper mapper)
           => mapper.Map<ThueTNCNDto>(projectFrom);

        public static List<ThueTNCNDto> MapToThueTNCNDtoList(this IEnumerable<ThueTNCNEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToThueTNCNDto(mapper)).ToList();
    }
}
