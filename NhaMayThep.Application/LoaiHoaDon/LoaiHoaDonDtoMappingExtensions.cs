using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.LoaiHoaDon
{
    public static class LoaiHoaDonDtoMappingExtensions
    {
        public static LoaiHoaDonDto MapToLoaiHoaDonDto(this LoaiHoaDonEntity projectFrom, IMapper mapper)
          => mapper.Map<LoaiHoaDonDto>(projectFrom);

        public static List<LoaiHoaDonDto> MapToLoaiHoaDonDtoList(this IEnumerable<LoaiHoaDonEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToLoaiHoaDonDto(mapper)).ToList();
    }
}
