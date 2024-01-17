using AutoMapper;

namespace NhaMayThep.Application.ThongTinChucVu
{
    public static class ChucVuMapToDto
    {
        public static ChucVuDto MapToChucVuDto(this NhaMapThep.Domain.Entities.ConfigTable.ThongTinChucVuEntity entity, IMapper mapper)
            => mapper.Map<ChucVuDto>(entity);
    }
}
