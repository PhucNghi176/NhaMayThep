using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.NghiPhep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NghiPhep
{
    public static class NghiPhepDtoMappingExtension
    {
        public static NghiPhepDto MapToNghiPhepDto(this NghiPhepEntity projectfrom, IMapper mapper)
        {
            return mapper.Map<NghiPhepDto>(projectfrom);

        }
        public static List<NghiPhepDto> MapToNghiPhepDtoList(this IEnumerable<NghiPhepEntity> projectFrom, IMapper mapper)
           => projectFrom.Select(x => x.MapToNghiPhepDto(mapper)).ToList();
    }
}
