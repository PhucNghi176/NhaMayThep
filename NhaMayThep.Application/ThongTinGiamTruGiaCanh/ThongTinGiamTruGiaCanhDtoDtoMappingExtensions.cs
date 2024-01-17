using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh
{
    public static class ThongTinGiamTruGiaCanhDtoDtoMappingExtensions
    {
        public static ThongTinGiamTruGiaCanhDto MapToThongTinGiamTruGiaCanhDto(this ThongTinGiamTruGiaCanhEntity projectFrom, IMapper mapper)
          => mapper.Map<ThongTinGiamTruGiaCanhDto>(projectFrom);

        public static List<ThongTinGiamTruGiaCanhDto> MapToThongTinGiamTruGiaCanhDtoList(this IEnumerable<ThongTinGiamTruGiaCanhEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToThongTinGiamTruGiaCanhDto(mapper)).ToList();
    }
}
