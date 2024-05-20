using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.KhenThuong
{
    public static class KhenThuongDTOMappingExstension
    {
        public static KhenThuongDTO MapToKhenThuongDTO(this KhenThuongEntity projectFrom, IMapper mapper)
           => mapper.Map<KhenThuongDTO>(projectFrom);

        public static List<KhenThuongDTO> MapToKhenThuongDTOList(this IEnumerable<KhenThuongEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToKhenThuongDTO(mapper)).ToList();

        public static KhenThuongDTO MapToKhenThuongDTO(this KhenThuongEntity entity, IMapper mapper, string chinhSachNhanSu, string tenNhanVien)
        {
            var dto = mapper.Map<KhenThuongDTO>(entity);
            dto.TenNhanVien = tenNhanVien;
            dto.ChinhSachNhanSu = chinhSachNhanSu;
            return dto;
        }

        public static List<KhenThuongDTO> MapToKhenThuongDTOList(this IEnumerable<KhenThuongEntity> entities, IMapper mapper, Dictionary<int, string> chinhSachNhanSu, Dictionary<string, string> tenNhanVien)
            => entities.Select(x =>
            x.MapToKhenThuongDTO(mapper,
                chinhSachNhanSu.ContainsKey(x.ChinhSachNhanSuID) ? chinhSachNhanSu[x.ChinhSachNhanSuID] : "Lỗi",
                tenNhanVien.ContainsKey(x.MaSoNhanVien) ? tenNhanVien[x.MaSoNhanVien] : "Lỗi"
            )).ToList();
    }
}
