using AutoMapper;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.QuaTrinhNhanSu
{
    public static class QuaTrinhNhanSuMappingExtension
    {
        public static QuaTrinhNhanSuDto MapToQuaTrinhNhanSuDto(this QuaTrinhNhanSuEntity projectFrom, IMapper mapper)
            => mapper.Map<QuaTrinhNhanSuDto>(projectFrom);

        public static List<QuaTrinhNhanSuDto> MapToQuaTrinhNhanSuDtoList(this IEnumerable<QuaTrinhNhanSuEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToQuaTrinhNhanSuDto(mapper)).ToList();
    }
}
