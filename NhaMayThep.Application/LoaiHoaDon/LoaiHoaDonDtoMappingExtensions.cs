using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHoaDon
{
    public static class LoaiHoaDonDtoMappingExtensions
    {
        public static LoaiHoaDonDto MapToLoaiHoaDonDto(this LoaiHoaDonEntity projectFrom, IMapper mapper)
          => mapper.Map<LoaiHoaDonDto>(projectFrom);

        public static List<LoaiHoaDonDto> MapToLoaiHoaDonDtoList(this IEnumerable<LoaiHoaDonEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToLoaiHoaDonDto(mapper)).ToList();
    }
}
