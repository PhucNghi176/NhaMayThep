using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu
{
    public static class ThongTinQuaTrinhNhanSuMappingExtension
    {
        public static ThongTinQuaTrinhNhanSuDto MapToThongTinQuaTrinhNhanSuDto(this ThongTinQuaTrinhNhanSuEntity projectFrom, IMapper mapper)
            => mapper.Map<ThongTinQuaTrinhNhanSuDto>(projectFrom);

        public static List<ThongTinQuaTrinhNhanSuDto> MapToThongTinQuaTrinhNhanSuDtoList(this IEnumerable<ThongTinQuaTrinhNhanSuEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToThongTinQuaTrinhNhanSuDto(mapper)).ToList();
    }
}
