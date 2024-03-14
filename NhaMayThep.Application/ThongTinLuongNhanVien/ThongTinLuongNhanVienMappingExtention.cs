using AutoMapper;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien
{
    public static class ThongTinLuongNhanVienMappingExtention
    {
        public static ThongTinLuongNhanVienDTO MapToThongTinLuongNhanVienDTO(this ThongTinLuongNhanVienEntity k, IMapper mapper)
        => mapper.Map<ThongTinLuongNhanVienDTO>(k);

        public static List<ThongTinLuongNhanVienDTO> MapToThongTinLuongNhanVienDtoList(this IEnumerable<ThongTinLuongNhanVienEntity> ks, IMapper mapper)
        => ks.Select(x => x.MapToThongTinLuongNhanVienDTO(mapper)).ToList();
    }
}
