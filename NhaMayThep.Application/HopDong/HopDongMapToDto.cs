using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.HopDong
{
    public static class HopDongMapToDto
    {
        public static HopDongDto MapToHopDongDto(this HopDongEntity hopDong, IMapper mapper)
            => mapper.Map<HopDongDto>(hopDong);

        public static HopDongDto MapToHopDongDto(this HopDongEntity hopDong, IMapper mapper, string chucDanh, string chucVu, string phuCap, string loaiHopDong, string hoVaTen)
        {
            var dto = mapper.Map<HopDongDto>(hopDong);
            dto.ChucDanh = chucDanh;
            dto.ChucVu = chucVu;
            dto.PhuCap = phuCap;
            dto.LoaiHopDong = loaiHopDong;
            dto.TenNhanVien = hoVaTen;
            return dto;
        }

        public static List<HopDongDto> MapToListHopDongDto(this List<HopDongEntity> entities, IMapper mapper, Dictionary<int, string> chucDanh, Dictionary<int, string> chucVu, Dictionary<int, string> phuCap, Dictionary<int, string> loaiHopDong, Dictionary<string, string> tenNhanVien)
        {
            return entities.Select(x =>
            {
                var phuCapIds = x.PhuCapID.Split(',').Select(int.Parse); // Split the PhuCapID string and convert to integers
                var phuCapNames = phuCapIds.Select(id => phuCap.ContainsKey(id) ? phuCap[id] : "Lỗi"); // Get the corresponding names
                var phuCapString = string.Join(", ", phuCapNames); // Join the names into a single string

                return x.MapToHopDongDto(mapper,
                    chucDanh.ContainsKey(x.ChucDanhID) ? chucDanh[x.ChucDanhID] : "Lỗi",
                    chucVu.ContainsKey(x.ChucVuID) ? chucVu[x.ChucVuID] : "Lỗi",
                    phuCapString,
                    loaiHopDong.ContainsKey(x.LoaiHopDongID) ? loaiHopDong[x.LoaiHopDongID] : "Lỗi",
                    tenNhanVien.ContainsKey(x.NhanVienID) ? tenNhanVien[x.NhanVienID] : "Lỗi");
            }).ToList();
        }

    }
}
