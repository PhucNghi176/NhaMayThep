using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.LichSuNghiPhep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiTangCa
{
    public static class DangKiTangCaDtoMappingExtension
    {
        public static DangKiTangCaDto MapToDangKiTangCaDto(this DangKiTangCaEntity projectfrom, IMapper mapper)
        {
            return mapper.Map<DangKiTangCaDto>(projectfrom);

        }
        public static List<DangKiTangCaDto> MapToDangKiTangCaDtoList(this IEnumerable<DangKiTangCaEntity> projectFrom, IMapper mapper)
           => projectFrom.Select(x => x.MapToDangKiTangCaDto(mapper)).ToList();
    }
}
