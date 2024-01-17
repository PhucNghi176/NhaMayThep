using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh
{
    public static class ThongTinGiamTruGiaCanhDtoDtoMappingExtensions
    {
        public static ThongTinGiamTruGiaCanhDto MapToThongTinGiamTruGiaCanhDto(this ThongTinGiamTruGiaCanhEntity projectFrom, IMapper mapper)
          => mapper.Map<ThongTinGiamTruGiaCanhDto>(projectFrom);

        public static List<ThongTinGiamTruGiaCanhDto> MapToThongTinGiamTruGiaCanhDtoList(this IEnumerable<ThongTinGiamTruGiaCanhEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToThongTinGiamTruGiaCanhDto(mapper)).ToList();
    }
}
