using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.ThongTinGiamTru
{
    public static class ThongTinGiamTruDTOMappingExstension
    {
        public static ThongTinGiamTruDTO MapToThongTinGiamTruDTO(this ThongTinGiamTruEntity projectFrom, IMapper mapper)
           => mapper.Map<ThongTinGiamTruDTO>(projectFrom);

        public static List<ThongTinGiamTruDTO> MapToThongTinGiamTruDTOList(this IEnumerable<ThongTinGiamTruEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToThongTinGiamTruDTO(mapper)).ToList();
    }
}
