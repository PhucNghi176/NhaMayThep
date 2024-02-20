using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.ThongTinGiamTru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
