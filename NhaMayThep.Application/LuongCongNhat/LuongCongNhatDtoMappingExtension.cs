using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.LuongCongNhat
{
    public static class LuongCongNhatDtoMappingExtension
    {
        public static LuongCongNhatDto MapToLuongCongNhatDto(this LuongCongNhatEntity projectfrom, IMapper mapper)
        {
            return mapper.Map<LuongCongNhatDto>(projectfrom);

        }
        public static List<LuongCongNhatDto> MapToLuongCongNhatDtoList(this IEnumerable<LuongCongNhatEntity> projectFrom, IMapper mapper)
           => projectFrom.Select(x => x.MapToLuongCongNhatDto(mapper)).ToList();
    }
}
