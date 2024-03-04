using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.LoaiCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec
{
    public static class TrangThaiDangKiCaLamViecDTOMappingExtension
    {
        public static TrangThaiDangKiCaLamViecDTO MapToTrangThaiDangKiCaLamViecDTO(this TrangThaiDangKiCaLamViecEntity projectFrom, IMapper mapper)
          => mapper.Map<TrangThaiDangKiCaLamViecDTO>(projectFrom);

        public static List<TrangThaiDangKiCaLamViecDTO> MapToTrangThaiDangKiCaLamViecDTOList(this IEnumerable<TrangThaiDangKiCaLamViecEntity> projectFrom, IMapper mapper)
          => projectFrom.Select(x => x.MapToTrangThaiDangKiCaLamViecDTO(mapper)).ToList();
    }
}
