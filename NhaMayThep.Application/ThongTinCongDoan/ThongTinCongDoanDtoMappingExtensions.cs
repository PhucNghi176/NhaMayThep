using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.ThongTinCongDoan
{
    public static class ThongTinGiamTruGiaCanhDtoDtoMappingExtensions
    {
        public static ThongTinCongDoanDto MapToThongTinCongDoanDto(this ThongTinCongDoanEntity entity, IMapper mapper)
          => mapper.Map<ThongTinCongDoanDto>(entity);

        public static List<ThongTinCongDoanDto> MapToThongTinCongDoanDtoList(this IEnumerable<ThongTinCongDoanEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToThongTinCongDoanDto(mapper)).ToList();

        public static ThongTinCongDoanDto MapToThongTinCongDoanDto(this ThongTinCongDoanEntity entity, IMapper mapper, string nhanvien)
        {
            var dto = mapper.Map<ThongTinCongDoanDto>(entity);
            dto.NhanVien = nhanvien;
            return dto;
        }
        public static List<ThongTinCongDoanDto> MapToThongTinCongDoanDtoList(this IEnumerable<ThongTinCongDoanEntity> entities, IMapper mapper, Dictionary<string, string> nhanvien)
           => entities.Select(x => x.MapToThongTinCongDoanDto(mapper, nhanvien.ContainsKey(x.NhanVienID) ? nhanvien[x.NhanVienID] : "Trống")).ToList();
    }
}
