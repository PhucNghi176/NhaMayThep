using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.LichSuCongTacNhanVien
{
    public static class LichSuCongTacNhanVienDtoMappingExtensions
    {
        public static LichSuCongTacNhanVienDto MapTolichSuCongTacNhanVienDto(this LichSuCongTacNhanVienEntity entity, IMapper mapper)
        {
            return mapper.Map<LichSuCongTacNhanVienDto>(entity);
        }

        public static LichSuCongTacNhanVienDto MapTolichSuCongTacNhanVienDto(this LichSuCongTacNhanVienEntity entity, IMapper mapper, string hovaten, string name)
        {
            var dto = mapper.Map<LichSuCongTacNhanVienDto>(entity);
            dto.HoVaTen = hovaten;
            dto.LoaiCongTac = name;
            return dto;
        }

        public static List<LichSuCongTacNhanVienDto> MapTolichSuCongTacNhanVienDtoList(this IEnumerable<LichSuCongTacNhanVienEntity> entities, IMapper mapper) => entities.Select(x => x.MapTolichSuCongTacNhanVienDto(mapper)).ToList();

        public static List<LichSuCongTacNhanVienDto> MapTolichSuCongTacNhanVienDtoList(this IEnumerable<LichSuCongTacNhanVienEntity> entities, IMapper mapper, Dictionary<string, string> HoVaTen, Dictionary<int, string> LoaiCongTac)
        =>
            entities.Select(x =>
            x.MapTolichSuCongTacNhanVienDto(mapper,
            HoVaTen.ContainsKey(x.MaSoNhanVien) ? HoVaTen[x.MaSoNhanVien] : "Lỗi",
        LoaiCongTac.ContainsKey(x.LoaiCongTacID) ? LoaiCongTac[x.LoaiCongTacID] : "Lỗi")).ToList();

    }
}
