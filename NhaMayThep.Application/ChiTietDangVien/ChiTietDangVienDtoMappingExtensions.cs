using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.DonViCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietDangVien
{
    public static class ChiTietDangVienDtoMappingExtensions
    {
        public static ChiTietDangVienDto MapToChiTietDangVienDto(this ChiTietDangVienEntity projectFrom, IMapper mapper)
            => mapper.Map<ChiTietDangVienDto>(projectFrom);

        public static List<ChiTietDangVienDto> MapToChiTietDangVienDtoList(this IEnumerable<ChiTietDangVienEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToChiTietDangVienDto(mapper)).ToList();
    }
}
