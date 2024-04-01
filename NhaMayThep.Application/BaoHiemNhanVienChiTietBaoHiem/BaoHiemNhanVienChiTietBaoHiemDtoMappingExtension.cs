using AutoMapper;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem
{
    public static class BaoHiemNhanVienChiTietBaoHiemDtoMappingExtension
    {
        public static BaoHiemNhanVienChiTietBaoHiemDto MapToBaoHiemNhanVienChiTietDto(this BaoHiemNhanVienBaoHiemChiTietEntity entity, IMapper mapper)
            => mapper.Map<BaoHiemNhanVienChiTietBaoHiemDto>(entity);
        public static BaoHiemNhanVienChiTietBaoHiemDto MapFullToBaoHiemNhanVienChiTietDto(this BaoHiemNhanVienBaoHiemChiTietEntity entity, IMapper mapper)
        {
            var map= mapper.Map<BaoHiemNhanVienChiTietBaoHiemDto>(entity);
            map.MaBaoHiemNhanVien = entity.BHNV;
            map.MaChiTietBaoHiem = entity.BHCT;
            map.MaNhanVien = entity.BaoHiemNhanVienEntity.MaSoNhanVien ??"";
            map.TenNhanVien = entity.BaoHiemNhanVienEntity.NhanVien.HoVaTen ?? "";
            map.LoaiBaoHiem = entity.ChiTietBaoHiemEntity.LoaiBaoHiem;
            map.NgayHieuLuc = entity.ChiTietBaoHiemEntity.NgayHieuLuc;
            map.NgayKetThuc = entity.ChiTietBaoHiemEntity.NgayKetThuc;
            map.NoiCap = entity.ChiTietBaoHiemEntity.NoiCap??"";
            map.PhanTramKhauTru = entity.ChiTietBaoHiemEntity.BaoHiem.PhanTramKhauTru;
            return map;
        }
        public static List<BaoHiemNhanVienChiTietBaoHiemDto> MapToBaoHiemNhanVienChiTietDtoToList(this ICollection<BaoHiemNhanVienBaoHiemChiTietEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToBaoHiemNhanVienChiTietDto(mapper)).ToList();
        public static List<BaoHiemNhanVienChiTietBaoHiemDto> MapFullToBaoHiemNhanVienChiTietDtoToList(this ICollection<BaoHiemNhanVienBaoHiemChiTietEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapFullToBaoHiemNhanVienChiTietDto(mapper)).ToList();
    }
}
