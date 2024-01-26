using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.KyLuat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong
{
    public static class KhenThuongDTOMappingExstension
    {
        public static KhenThuongDTO MapToKhenThuongDTO(this KhenThuongEntity projectFrom, IMapper mapper)
           => mapper.Map<KhenThuongDTO>(projectFrom);

        public static List<KhenThuongDTO> MapToKhenThuongDTOList(this IEnumerable<KhenThuongEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToKhenThuongDTO(mapper)).ToList();
    }
}
