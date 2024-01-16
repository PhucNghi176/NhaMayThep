using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien
{
    public static class LichSuCongTacNhanVienDtoMappingExtensions
    {
        public static LichSuCongTacNhanVienDto MapToLichSuCongTacNhanVienDto(this LichSuCongTacNhanVienEntity projectFrom, IMapper mapper)
            => mapper.Map<LichSuCongTacNhanVienDto>(projectFrom);

        public static List<LichSuCongTacNhanVienDto> MapToLichSuCongTacNhanVienDtoList(this IEnumerable<LichSuCongTacNhanVienEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToLichSuCongTacNhanVienDto(mapper)).ToList();
    }
}
