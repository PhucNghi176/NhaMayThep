using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.PhongBan
{
    public static class PhongBanMappingExtension
    {
        public static PhongBanDto MapToPhongBanDto(this PhongBanEntity projectFrom, IMapper mapper)
            => mapper.Map<PhongBanDto>(projectFrom);

        public static List<PhongBanDto> MapToPhongBanDtoList(this IEnumerable<PhongBanEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToPhongBanDto(mapper)).ToList();
    }
}
