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
        public static NhanVienDto MapToNhanVienDto(this NhanVienEntity entity, IMapper mapper, string chucVu, string tinhTrangLamViec)
        {
            var dto = mapper.Map<NhanVienDto>(entity);
            dto.ChucVuID = chucVu;
            dto.TinhTrangLamViecID = tinhTrangLamViec;
            return dto;
        }     
        public static List<NhanVienDto> MapToNhanVienDtoList(this IEnumerable<NhanVienEntity> entities, IMapper mapper, Dictionary<int, string> chucVu, Dictionary<int, string> tinhTrangLamViec)
            => entities.Select(x => x.MapToNhanVienDto(mapper, chucVu.ContainsKey(x.ChucVuID) ? chucVu[x.ChucVuID] : "Lỗi", tinhTrangLamViec.ContainsKey(x.TinhTrangLamViecID) ? tinhTrangLamViec[x.TinhTrangLamViecID] : "Lỗi")).ToList();

    }
}

