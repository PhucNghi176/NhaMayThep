using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.DangKiTangCa
{
    public static class DangKiTangCaDtoMappingExtension
    {
        public static DangKiTangCaDto MapToDangKiTangCaDto(this DangKiTangCaEntity projectfrom, IMapper mapper)
        {
            return mapper.Map<DangKiTangCaDto>(projectfrom);

        }
        public static List<DangKiTangCaDto> MapToDangKiTangCaDtoList(this IEnumerable<DangKiTangCaEntity> projectFrom, IMapper mapper)
           => projectFrom.Select(x => x.MapToDangKiTangCaDto(mapper)).ToList();
    }
}
