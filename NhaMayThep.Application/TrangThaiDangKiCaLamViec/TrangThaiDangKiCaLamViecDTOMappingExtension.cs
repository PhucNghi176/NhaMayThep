using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

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
