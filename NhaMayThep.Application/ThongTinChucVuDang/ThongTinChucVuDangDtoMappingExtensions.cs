using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.ThongTinCapDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVuDang
{
    public static class ThongTinChucVuDangDtoMappingExtensions
    {
        public static ThongTinChucVuDangDto MapToThongTinChucVuDangDto(this ThongTinChucVuDangEntity thongTinChucVuDang, IMapper mapper)
            => mapper.Map<ThongTinChucVuDangDto>(thongTinChucVuDang);

        public static List<ThongTinChucVuDangDto> MapToThongTinChucVuDangDtoList(this IEnumerable<ThongTinChucVuDangEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToThongTinChucVuDangDto(mapper)).ToList();
    }
}
