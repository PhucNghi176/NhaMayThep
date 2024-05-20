using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.LuongSanPham
{
    public static class LuongSanPhamDtoMappingExtension
    {
        public static LuongSanPhamDto MapToLuongSanPhamDto(this LuongSanPhamEntity projectfrom, IMapper mapper)
        {
            return mapper.Map<LuongSanPhamDto>(projectfrom);

        }
        public static List<LuongSanPhamDto> MapToLuongSanPhamDtoList(this IEnumerable<LuongSanPhamEntity> projectFrom, IMapper mapper)
           => projectFrom.Select(x => x.MapToLuongSanPhamDto(mapper)).ToList();
    }
}
