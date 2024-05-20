using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.LoaiNghiPhep
{
    public static class LoaiNghiPhepDtoMappingExtension
    {
        public static LoaiNghiPhepDto MapToLoaiNghiPhepDto(this LoaiNghiPhepEntity projectfrom, IMapper mapper)
        {
            return mapper.Map<LoaiNghiPhepDto>(projectfrom);

        }
        public static List<LoaiNghiPhepDto> MapToLoaiNghiPhepDtoList(this IEnumerable<LoaiNghiPhepEntity> projectFrom, IMapper mapper)
           => projectFrom.Select(x => x.MapToLoaiNghiPhepDto(mapper)).ToList();
    }
}