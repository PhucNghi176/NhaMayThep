using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.ChiTietBaoHiem
{
    public static class ChiTietBaoHiemDtoMappingExtension
    {
        public static ChiTietBaoHiemDto MapToChiTietBaoHiemDto(this ChiTietBaoHiemEntity entity, IMapper mapper)
            => mapper.Map<ChiTietBaoHiemDto>(entity);

        public static List<ChiTietBaoHiemDto> MapToChiTietBaoHiemDtoList(this IEnumerable<ChiTietBaoHiemEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToChiTietBaoHiemDto(mapper)).ToList();

        public static ChiTietBaoHiemDto MapToChiTietBaoHiemDto(this ChiTietBaoHiemEntity entity, IMapper mapper, string? baohiem)
        {
            var dto = mapper.Map<ChiTietBaoHiemDto>(entity);
            dto.BaoHiem = baohiem ?? "Trống";
            dto.PhanTramBaoHiem = entity.BaoHiem.PhanTramKhauTru.ToString() ?? null;
            return dto;
        }
        public static List<ChiTietBaoHiemDto> MapToChiTietBaoHiemDtoList(this IEnumerable<ChiTietBaoHiemEntity> entities, IMapper mapper, Dictionary<int, string> baohiem)
           => entities.Select(x => x.MapToChiTietBaoHiemDto(mapper,
               baohiem.ContainsKey(x.LoaiBaoHiem) ? baohiem[x.LoaiBaoHiem] : "Trống")).ToList();
    }
}
