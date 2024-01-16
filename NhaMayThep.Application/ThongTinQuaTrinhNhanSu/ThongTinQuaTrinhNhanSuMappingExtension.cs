using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.QuaTrinhNhanSu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu
{
    public static class ThongTinQuaTrinhNhanSuMappingExtension
    {
        public static ThongTinQuaTrinhNhanSuDto MapToThongTinQuaTrinhNhanSuDto(this ThongTinQuaTrinhNhanSuEntity projectFrom, IMapper mapper)
            => mapper.Map<ThongTinQuaTrinhNhanSuDto>(projectFrom);

        public static List<ThongTinQuaTrinhNhanSuDto> MapToThongTinQuaTrinhNhanSuDtoList(this IEnumerable<ThongTinQuaTrinhNhanSuEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToThongTinQuaTrinhNhanSuDto(mapper)).ToList();
    }
}
