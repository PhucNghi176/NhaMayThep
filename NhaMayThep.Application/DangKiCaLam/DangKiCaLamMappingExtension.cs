using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.DangKiCaLam
{
    public static class DangKiCaLamMappingExtension
    {
        public static DangKiCaLamDto MapToDangKiCaLamDto(this DangKiCaLamEntity projectfrom, IMapper mapper)
        {
            return mapper.Map<DangKiCaLamDto>(projectfrom);

        }

        public static List<DangKiCaLamDto> MapToDangKiCaLamDtoList(this IEnumerable<DangKiCaLamEntity> projectFrom, IMapper mapper)
        => projectFrom.Select(x => x.MapToDangKiCaLamDto(mapper)).ToList();
    }
}
