using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.LichSuNghiPhep
{
    public static class LichSuNghiPhepMappsingExtension
    {
        public static LichSuNghiPhepDto MapToLichSuNghiPhepDto(this LichSuNghiPhepNhanVienEntity projectfrom, IMapper mapper)
        {
            return mapper.Map<LichSuNghiPhepDto>(projectfrom);

        }
        public static List<LichSuNghiPhepDto> MapToLichSuNghiPhepDtoList(this IEnumerable<LichSuNghiPhepNhanVienEntity> projectFrom, IMapper mapper)
           => projectFrom.Select(x => x.MapToLichSuNghiPhepDto(mapper)).ToList();

    }
}