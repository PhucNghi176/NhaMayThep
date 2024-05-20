using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep
{
    public static class ChiTietNgayNghiPhepMappingExtension
    {
        public static ChiTietNgayNghiPhepDto MapToChiTietNgayNghiPhepDto(this ChiTietNgayNghiPhepEntity projectfrom, IMapper mapper)
        {
            return mapper.Map<ChiTietNgayNghiPhepDto>(projectfrom);
        }
        public static List<ChiTietNgayNghiPhepDto> MapToChiTietNgayNghiPhepDtoList(this IEnumerable<ChiTietNgayNghiPhepEntity> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToChiTietNgayNghiPhepDto(mapper)).ToList();
        }

    }
}
