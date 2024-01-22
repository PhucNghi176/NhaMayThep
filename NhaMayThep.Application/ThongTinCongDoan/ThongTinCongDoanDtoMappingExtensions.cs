using AutoMapper;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Application.ThongTinCongDoan
{
    public static class ThongTinGiamTruGiaCanhDtoDtoMappingExtensions
    {
        public static ThongTinCongDoanDto MapToThongTinCongDoanDto(this ThongTinCongDoanEntity projectFrom, IMapper mapper)
          => mapper.Map<ThongTinCongDoanDto>(projectFrom);

        public static List<ThongTinCongDoanDto> MapToThongTinCongDoanDtoList(this IEnumerable<ThongTinCongDoanEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToThongTinCongDoanDto(mapper)).ToList();
    }
}
