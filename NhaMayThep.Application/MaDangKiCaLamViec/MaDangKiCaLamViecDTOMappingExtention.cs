using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MaDangKiCaLamViec
{
    public static class MaDangKiCaLamViecDTOMappingExtention
    {
        public static MaDangKiCaLamViecDTO MapToMaDangKiCaLamViecDTO(this MaDangKiCaLamEntity projectFrom, IMapper mapper)
          => mapper.Map<MaDangKiCaLamViecDTO>(projectFrom);

        public static List<MaDangKiCaLamViecDTO> MapToMaDangKiCaLamViecDTOList(this IEnumerable<MaDangKiCaLamEntity> projectFrom, IMapper mapper)
          => projectFrom.Select(x => x.MapToMaDangKiCaLamViecDTO(mapper)).ToList();
    }
}
