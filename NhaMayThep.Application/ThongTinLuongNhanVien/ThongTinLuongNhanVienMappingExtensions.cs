using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.KhaiBaoTangLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien
{
    public static class ThongTinLuongNhanVienMappingExtensions
    {
        public static ThongTinLuongNhanVienDto MapToThongTinLuongNhanVienDto(this ThongTinLuongNhanVienEntity k, IMapper mapper)
        => mapper.Map<ThongTinLuongNhanVienDto>(k);

        public static List<ThongTinLuongNhanVienDto> MapToThongTinLuongNhanVienDtoList(this IEnumerable<ThongTinLuongNhanVienEntity> ks, IMapper mapper)
        => ks.Select(x => x.MapToThongTinLuongNhanVienDto(mapper)).ToList();
    }
}
