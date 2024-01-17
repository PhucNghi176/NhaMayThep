using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.LoaiCongTac
{
    public static class LoaiCongTacDtoMappingExtensions
    {
        public static LoaiCongTacDto MapToLoaiCongTacDto(this LoaiCongTacEntity projectFrom, IMapper mapper)
          => mapper.Map<LoaiCongTacDto>(projectFrom);

        public static List<LoaiCongTacDto> MapToLoaiCongTacDtoList(this IEnumerable<LoaiCongTacEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToLoaiCongTacDto(mapper)).ToList();
    }
}
