using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.QuaTrinhNhanSu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhongBan
{
    public static class PhongBanMappingExtension
    {
        public static PhongBanDto MapToPhongBanDto(this PhongBanEntity projectFrom, IMapper mapper)
            => mapper.Map<PhongBanDto>(projectFrom);

        public static List<PhongBanDto> MapToPhongBanDtoList(this IEnumerable<PhongBanEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToPhongBanDto(mapper)).ToList();
    }
}
