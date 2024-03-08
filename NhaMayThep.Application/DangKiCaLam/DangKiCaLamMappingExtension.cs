using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.DangKiTangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiCaLam
{
    public static class DangKiCaLamMappingExtension
    {
        public static DangKiCaLamDto MapToDangKiCaLamDto(this DangKiCaLamEntity projectfrom, IMapper mapper)
        {
            return mapper.Map<DangKiCaLamDto>(projectfrom);

        }

        public static List<DangKiCaLamDto> MapToDangKiCaLamDtoList(this IEnumerable<DangKiCaLamEntity> projectFrom, IMapper mapper)
        => projectFrom.Select(x => x.MapToDangKiCaLamDto(mapper)).ToList();
    }
}
