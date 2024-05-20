using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh
{
    public static class ThongTinGiamTruGiaCanhDtoDtoMappingExtensions
    {
        public static ThongTinGiamTruGiaCanhDto MapToThongTinGiamTruGiaCanhDto(this ThongTinGiamTruGiaCanhEntity entity, IMapper mapper)
          => mapper.Map<ThongTinGiamTruGiaCanhDto>(entity);

        public static List<ThongTinGiamTruGiaCanhDto> MapToThongTinGiamTruGiaCanhDtoList(this IEnumerable<ThongTinGiamTruGiaCanhEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToThongTinGiamTruGiaCanhDto(mapper)).ToList();
        public static ThongTinGiamTruGiaCanhDto MapToThongTinGiamTruGiaCanhDto(
            this ThongTinGiamTruGiaCanhEntity entity,
            IMapper mapper,
            string nhanvien,
            string giamtru)
        {
            var dto = mapper.Map<ThongTinGiamTruGiaCanhDto>(entity);
            dto.NhanVien = nhanvien;
            dto.ThongTinGiamTru = giamtru;
            return dto;
        }
        public static List<ThongTinGiamTruGiaCanhDto> MapToThongTinGiamTruGiaCanhDtoList(
            this IEnumerable<ThongTinGiamTruGiaCanhEntity> entities,
            IMapper mapper,
            Dictionary<string, string> nhanviens,
            Dictionary<int, string> giamtrus)
            => entities.Select(x => x.MapToThongTinGiamTruGiaCanhDto(mapper,
                nhanviens.ContainsKey(x.NhanVienID) ? nhanviens[x.NhanVienID] : "Trống",
                giamtrus.ContainsKey(x.MaGiamTruID) ? giamtrus[x.MaGiamTruID] : "Trống")).ToList();
    }
}
