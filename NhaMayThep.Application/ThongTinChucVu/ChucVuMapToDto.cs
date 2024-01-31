using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.ThongTinChucVu
{
    public static class ChucVuMapToDto
    {
        public static ChucVuDto MapToChucVuDto(this NhaMapThep.Domain.Entities.ConfigTable.ThongTinChucVuEntity entity, IMapper mapper)
            => mapper.Map<ChucVuDto>(entity);
        public static List<ChucVuDto> MapToChucVuDtoList(this IEnumerable<ThongTinChucVuEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToChucVuDto(mapper)).ToList();
    }
}
