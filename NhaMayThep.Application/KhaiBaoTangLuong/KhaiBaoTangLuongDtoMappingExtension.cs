using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.LuongCongNhat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong
{
    public static class LuongCongNhatDtoMappingExtensions
    {
        public static KhaiBaoTangLuongDto MapToKhaiBaoTangLuongDto(this KhaiBaoTangLuongEntity projectFrom, IMapper mapper)
            => mapper.Map<KhaiBaoTangLuongDto>(projectFrom);

        public static List<KhaiBaoTangLuongDto> MapToKhaiBaoTangLuongDtoList(this IEnumerable<KhaiBaoTangLuongEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToKhaiBaoTangLuongDto(mapper)).ToList();
    }
}
