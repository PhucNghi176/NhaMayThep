using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.ThongTinDaoTao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NghiPhep
{
    public static class NghiPhepDtoMappingExtensions
    {
        public static NghiPhepDto MapToNghiPhepDto(this NghiPhepEntity entity, IMapper mapper)
            => mapper.Map<NghiPhepDto>(entity);

        public static List<NghiPhepDto> MapToNghiPhepDtoList(this IEnumerable<NghiPhepEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToNghiPhepDto(mapper)).ToList();
    }
}
