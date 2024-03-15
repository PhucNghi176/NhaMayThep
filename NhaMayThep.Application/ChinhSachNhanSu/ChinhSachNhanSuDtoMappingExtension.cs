using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.MucSanPham;
using NhaMayThep.Application.QuaTrinhNhanSu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu
{
    public static class ChinhSachNhanSuDtoMappingExtension
    {
        public static ChinhSachNhanSuDto MapToChinhSachNhanSuDto(this ChinhSachNhanSuEntity projectFrom, IMapper mapper)
            => mapper.Map<ChinhSachNhanSuDto>(projectFrom);

        public static List<ChinhSachNhanSuDto> MapToChinhSachNhanSuDtoList(this IEnumerable<ChinhSachNhanSuEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToChinhSachNhanSuDto(mapper)).ToList();
    }
}
