using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.QuaTrinhNhanSu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MucSanPham
{
    public static class MucSanPhamMappingExtension
    {
        public static MucSanPhamDto MapToMucSanPhamDto(this MucSanPhamEntity projectFrom, IMapper mapper)
            => mapper.Map<MucSanPhamDto>(projectFrom);

        public static List<MucSanPhamDto> MapToMucSanPhamDtoList(this IEnumerable<MucSanPhamEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToMucSanPhamDto(mapper)).ToList();
    }
}
