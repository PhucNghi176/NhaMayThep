using AutoMapper;

namespace NhaMayThep.Application.ThongTinPhuCap
{
    public static class PhuCapMapToDto
    {
        public static PhuCapDto MapToPhuCapDto(this NhaMapThep.Domain.Entities.ConfigTable.ThongTinPhuCapEntity entity, IMapper mapper)
            => mapper.Map<PhuCapDto>(entity);
    }
}
