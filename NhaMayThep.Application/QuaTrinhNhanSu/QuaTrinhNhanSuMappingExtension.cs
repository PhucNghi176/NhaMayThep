using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.NhanVien;

namespace NhaMayThep.Application.QuaTrinhNhanSu
{
    public static class QuaTrinhNhanSuMappingExtension
    {
        public static QuaTrinhNhanSuDto MapToQuaTrinhNhanSuDto(this QuaTrinhNhanSuEntity projectFrom, IMapper mapper)
            => mapper.Map<QuaTrinhNhanSuDto>(projectFrom);

        public static List<QuaTrinhNhanSuDto> MapToQuaTrinhNhanSuDtoList(this IEnumerable<QuaTrinhNhanSuEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToQuaTrinhNhanSuDto(mapper)).ToList();

        public static QuaTrinhNhanSuDto MapToQuaTrinhNhanSuDto(this QuaTrinhNhanSuEntity entity, IMapper mapper, string loaiQuaTrinh, string phongBan, string chucVu, string chucDanh, string hoVaTen)
        {
            var dto = mapper.Map<QuaTrinhNhanSuDto>(entity);
            dto.HoVaTen = hoVaTen;
            dto.LoaiQuaTrinh = loaiQuaTrinh;
            dto.PhongBan = phongBan;
            dto.ChucVu = chucVu;
            dto.ChucDanh = chucDanh;
            return dto;
        }

        public static List<QuaTrinhNhanSuDto> MapToQuaTrinhNhanSuDtoList(this IEnumerable<QuaTrinhNhanSuEntity> entities, IMapper mapper, Dictionary<int, string> loaiQuaTrinh, Dictionary<int, string> phongBan, Dictionary<int, string> chucVu, Dictionary<int, string> chucDanh, Dictionary<string, string> hoVaTen)
            => entities.Select(x =>
            x.MapToQuaTrinhNhanSuDto(mapper,               
                loaiQuaTrinh.ContainsKey(x.LoaiQuaTrinhID) ? loaiQuaTrinh[x.LoaiQuaTrinhID] : "Lỗi",
                phongBan.ContainsKey(x.PhongBanID) ? phongBan[x.PhongBanID] : "Lỗi",
                chucVu.ContainsKey(x.ChucVuID) ? chucVu[x.ChucVuID] : "Lỗi",
                chucDanh.ContainsKey(x.ChucDanhID) ? chucDanh[x.ChucDanhID] : "Lỗi" ,
                hoVaTen.ContainsKey(x.MaSoNhanVien) ? hoVaTen[x.MaSoNhanVien] : "Lỗi"
            )).ToList();
    }
}
