using AutoMapper;
using NhaMapThep.Domain.Entities;

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
