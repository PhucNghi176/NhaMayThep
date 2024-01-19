using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru
{
    public static class ThongTinGiamTruDTOMappingExstension
    {
        public static ThongTinGiamTruDTO MapToThongTinGiamTruDTO(this ThongTinGiamTruEntity projectFrom, IMapper mapper)
           => mapper.Map<ThongTinGiamTruDTO>(projectFrom);

        public static List<ThongTinGiamTruDTO> MapToThongTinGiamTruDTOList(this IEnumerable<ThongTinGiamTruEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToThongTinGiamTruDTO(mapper)).ToList();
    }
}
