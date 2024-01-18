using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.ThongTinCongTy
{
    public static class ThongTinCongTyMappingExstension
    {
        public static ThongTinCongTyDto MapToThongTinCongTyDto(this ThongTinCongTyEntity entity, IMapper mapper)
            => mapper.Map<ThongTinCongTyDto>(entity);
    }
}