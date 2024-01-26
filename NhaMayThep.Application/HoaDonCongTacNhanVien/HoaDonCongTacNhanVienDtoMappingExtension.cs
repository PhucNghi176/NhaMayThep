using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.LichSuCongTacNhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien
{
    public static class HoaDonCongTacNhanVienDtoMappingExtension
    {
        public static HoaDonCongTacNhanVienDto MapToHoaDonCongTacNhanVienDto(this HoaDonCongTacNhanVienEntity projectFrom, IMapper mapper)
           => mapper.Map<HoaDonCongTacNhanVienDto>(projectFrom);

        public static List<HoaDonCongTacNhanVienDto> MapToHoaDonCongTacNhanVienDtoList(this IEnumerable<HoaDonCongTacNhanVienEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToHoaDonCongTacNhanVienDto(mapper)).ToList();
    }
}
