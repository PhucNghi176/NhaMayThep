using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.DonViCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien
{
    public static class ThongTinDangVienDtoMappingExtensions
    {
        public static ThongTinDangVienDto MapToThongTinDangVienDto(this ThongTinDangVienEntity projectFrom, IMapper mapper)
            => mapper.Map<ThongTinDangVienDto>(projectFrom);

        public static List<ThongTinDangVienDto> MapToThongTinDangVienDtoList(this IEnumerable<ThongTinDangVienEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToThongTinDangVienDto(mapper)).ToList();
    }
}
