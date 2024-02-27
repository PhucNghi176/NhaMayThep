using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.NhanVien
{
    public static class NhanVienDtoMappingExstensions
    {
        public static NhanVienDtoLogin MapToNhanVienDtoLogin(this NhanVienEntity entity, IMapper mapper)
            => mapper.Map<NhanVienDtoLogin>(entity);

        public static NhanVienDto MapToNhanVienDto(this NhanVienEntity entity, IMapper mapper)
            => mapper.Map<NhanVienDto>(entity);

        public static List<NhanVienDto> MapToNhanVienDtoList(this IEnumerable<NhanVienEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToNhanVienDto(mapper)).ToList();
        public static NhanVienDto MapToNhanVienDto(this NhanVienEntity entity, IMapper mapper, string chucVu, string tinhTrangLamViec, string? canCuocCongDan)
        {
            var dto = mapper.Map<NhanVienDto>(entity);
            dto.ChucVu = chucVu;
            dto.TinhTrangLamViec = tinhTrangLamViec;
            dto.CanCuocCongDan = canCuocCongDan;
            return dto;
        }
        public static List<NhanVienDto> MapToNhanVienDtoList(this IEnumerable<NhanVienEntity> entities, IMapper mapper, Dictionary<int, string> chucVu, Dictionary<int, string> tinhTrangLamViec, Dictionary<string, string>? canCuocCongDan)
            => entities.Select(x =>
            x.MapToNhanVienDto(mapper,
                chucVu.ContainsKey(x.ChucVuID) ? chucVu[x.ChucVuID] : "Lỗi",
                tinhTrangLamViec.ContainsKey(x.TinhTrangLamViecID) ? tinhTrangLamViec[x.TinhTrangLamViecID] : "Lỗi",
                canCuocCongDan.ContainsKey(x.ID) ? canCuocCongDan[x.ID] : "Lỗi"
            )).ToList();

    }
}

