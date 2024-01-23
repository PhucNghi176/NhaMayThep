using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.LuongCongNhat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongCongNhat
{
    public static class LuongCongNhatDtoMappingExtensions
    {
        public static LuongCongNhatDto MapToLuongCongNhatDto(this LuongCongNhatEntity projectFrom, IMapper mapper)
            => mapper.Map<LuongCongNhatDto>(projectFrom);

        public static List<LuongCongNhatDto> MapToLuongCongNhatDtoList(this IEnumerable<LuongCongNhatEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToLuongCongNhatDto(mapper)).ToList();
    }
}
