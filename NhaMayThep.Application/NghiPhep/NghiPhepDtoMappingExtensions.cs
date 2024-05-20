using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.NghiPhep
{
    public static class NghiPhepDtoMappingExtensions
    {
        public static NghiPhepDto MapToNghiPhepDto(this NghiPhepEntity entity, IMapper mapper)
            => mapper.Map<NghiPhepDto>(entity);

        public static List<NghiPhepDto> MapToNghiPhepDtoList(this IEnumerable<NghiPhepEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToNghiPhepDto(mapper)).ToList();
    }
}
