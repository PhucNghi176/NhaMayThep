using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.ThongTinPhuCap
{
    public static class PhuCapMapToDto
    {
        public static PhuCapDto MapToPhuCapDto(this NhaMapThep.Domain.Entities.ConfigTable.ThongTinPhuCapEntity entity, IMapper mapper)
            => mapper.Map<PhuCapDto>(entity);
        public static List<PhuCapDto> MapToListDto(this IEnumerable<ThongTinPhuCapEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToPhuCapDto(mapper)).ToList();
    }
}
