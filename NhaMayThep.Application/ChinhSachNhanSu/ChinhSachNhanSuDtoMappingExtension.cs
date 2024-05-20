using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.ChinhSachNhanSu
{
    public static class ChinhSachNhanSuDtoMappingExtension
    {
        public static ChinhSachNhanSuDto MapToChinhSachNhanSuDto(this ChinhSachNhanSuEntity projectFrom, IMapper mapper)
            => mapper.Map<ChinhSachNhanSuDto>(projectFrom);

        public static List<ChinhSachNhanSuDto> MapToChinhSachNhanSuDtoList(this IEnumerable<ChinhSachNhanSuEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToChinhSachNhanSuDto(mapper)).ToList();
    }
}
