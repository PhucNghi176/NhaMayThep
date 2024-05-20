using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.MucSanPham
{
    public static class MucSanPhamMappingExtension
    {
        public static MucSanPhamDto MapToMucSanPhamDto(this MucSanPhamEntity projectFrom, IMapper mapper)
            => mapper.Map<MucSanPhamDto>(projectFrom);

        public static List<MucSanPhamDto> MapToMucSanPhamDtoList(this IEnumerable<MucSanPhamEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToMucSanPhamDto(mapper)).ToList();
    }
}
