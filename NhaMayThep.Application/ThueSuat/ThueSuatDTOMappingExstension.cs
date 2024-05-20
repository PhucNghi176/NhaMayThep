using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.ThueSuat
{
    public static class ThueSuatDTOMappingExstension
    {
        public static ThueSuatDTO MapToThueSuatDTO(this ThueSuatEntity projectFrom, IMapper mapper)
           => mapper.Map<ThueSuatDTO>(projectFrom);

        public static List<ThueSuatDTO> MapToThueSuatDTOList(this IEnumerable<ThueSuatEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToThueSuatDTO(mapper)).ToList();
    }
}
