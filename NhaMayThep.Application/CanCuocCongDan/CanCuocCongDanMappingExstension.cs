using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.CanCuocCongDan
{
    public static class CanCuocCongDanMappingExstension
    {
        public static CanCuocCongDanDto MapToCanCuocCongDanDto(this CanCuocCongDanEntity entity, IMapper mapper)
       => mapper.Map<CanCuocCongDanDto>(entity);

    }
}
