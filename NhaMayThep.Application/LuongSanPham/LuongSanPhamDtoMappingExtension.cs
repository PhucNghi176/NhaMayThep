using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.LuongSanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham
{
    public static class LuongSanPhamDtoMappingExtensions
    {
        public static LuongSanPhamDto MapToLuongSanPhamDto(this LuongSanPhamEntity projectFrom, IMapper mapper)
            => mapper.Map<LuongSanPhamDto>(projectFrom);

        public static List<LuongSanPhamDto> MapToLuongSanPhamDtoList(this IEnumerable<LuongSanPhamEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToLuongSanPhamDto(mapper)).ToList();
    }
}
