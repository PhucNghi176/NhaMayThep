using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri
{
    public static class ThongTinTrinhDoChinhTriDtoMappingExtensions
    {
        public static ThongTinTrinhDoChinhTriDto MapToThongTinTrinhDoChinhTriDto(this ThongTinTrinhDoChinhTriEntity thongTinTrinhDoChinhTri, IMapper mapper)
            => mapper.Map<ThongTinTrinhDoChinhTriDto>(thongTinTrinhDoChinhTri);

        public static List<ThongTinTrinhDoChinhTriDto> MapToThongTinTrinhDoChinhTriDtoList(this IEnumerable<ThongTinTrinhDoChinhTriEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToThongTinTrinhDoChinhTriDto(mapper)).ToList();
    }
}
