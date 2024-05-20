using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri
{
    public static class ThongTinTrinhDoChinhTriDtoMappingExtensions
    {
        public static ThongTinTrinhDoChinhTriDto MapToThongTinTrinhDoChinhTriDto(this ThongTinTrinhDoChinhTriEntity thongTinTrinhDoChinhTri, IMapper mapper)
            => mapper.Map<ThongTinTrinhDoChinhTriDto>(thongTinTrinhDoChinhTri);

        public static List<ThongTinTrinhDoChinhTriDto> MapToThongTinTrinhDoChinhTriDtoList(this IEnumerable<ThongTinTrinhDoChinhTriEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToThongTinTrinhDoChinhTriDto(mapper)).ToList();
    }
}
