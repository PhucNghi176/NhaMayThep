using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.BangLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BangLuong
{
    public static class BangLuongDtoMappingExtension
    {
        public static BangLuongDto MapToBangLuongDto(this BangLuongEntity projectfrom, IMapper mapper)
        {
            return mapper.Map<BangLuongDto>(projectfrom);

        }
        public static List<BangLuongDto> MapToBangLuongDtoList(this IEnumerable<BangLuongEntity> projectFrom, IMapper mapper)
           => projectFrom.Select(x => x.MapToBangLuongDto(mapper)).ToList();
    }
}
