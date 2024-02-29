using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.ThongTinCongDoan;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem
{
    public static class ChiTietBaoHiemDtoMappingExtension
    {
        public static ChiTietBaoHiemDto MapToChiTietBaoHiemDto(this ChiTietBaoHiemEntity entity, IMapper mapper)
            => mapper.Map<ChiTietBaoHiemDto>(entity);

        public static List<ChiTietBaoHiemDto> MapToChiTietBaoHiemDtoList(this IEnumerable<ChiTietBaoHiemEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToChiTietBaoHiemDto(mapper)).ToList();

        public static ChiTietBaoHiemDto MapToChiTietBaoHiemDto(this ChiTietBaoHiemEntity entity, IMapper mapper, string? nhanvien, string? baohiem)
        {
            var dto = mapper.Map<ChiTietBaoHiemDto>(entity);
            dto.NhanVien = nhanvien ?? "Trống";
            dto.BaoHiem = baohiem ?? "Trống";
            return dto;
        }
        public static List<ChiTietBaoHiemDto> MapToChiTietBaoHiemDtoList(this IEnumerable<ChiTietBaoHiemEntity> entities, IMapper mapper, Dictionary<string, string> nhanvien, Dictionary<int, string> baohiem)
           => entities.Select(x => x.MapToChiTietBaoHiemDto(mapper, 
               nhanvien.ContainsKey(x.MaSoNhanVien) ? nhanvien[x.MaSoNhanVien] : "Trống",
               baohiem.ContainsKey(x.LoaiBaoHiem) ? baohiem[x.LoaiBaoHiem] : "Trống")).ToList();
    }
}
