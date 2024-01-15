using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap
{
    public static class ThongTinPhuCapDTOMappingExstension
    {
        public static ThongTinPhuCapDTO MapToThongTinPhuCapDTO(this ThongTinPhuCapEntity projectFrom, IMapper mapper)
           => mapper.Map<ThongTinPhuCapDTO>(projectFrom);

        public static List<ThongTinPhuCapDTO> MapToThongTinPhuCapDTOList(this IEnumerable<ThongTinPhuCapEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToThongTinPhuCapDTO(mapper)).ToList();
    }
}
