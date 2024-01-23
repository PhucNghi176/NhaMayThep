using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.ChiTietDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CapBacLuong
{
    public static class CapBacLuongMappingExstension
    {
        public static CapbacLuongDto MaptoCapBacLuongDto(this CapBacLuongEntity projectFrom, IMapper mapper)
        => mapper.Map<CapbacLuongDto>(projectFrom);

        public static List<ChiTietDangVienDto> MapToChiTietDangVienDtoList(this IEnumerable<ChiTietDangVienEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToChiTietDangVienDto(mapper)).ToList();
    }
}
