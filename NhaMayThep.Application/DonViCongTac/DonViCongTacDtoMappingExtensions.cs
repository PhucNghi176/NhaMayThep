using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace NhaMayThep.Application.DonViCongTac
{
    public static class DonViCongTacDtoMappingExtensions
    {
        public static DonViCongTacDto MapToDonViCongTacDto(this DonViCongTacEntity projectFrom, IMapper mapper)
            => mapper.Map<DonViCongTacDto>(projectFrom);

        public static List<DonViCongTacDto> MapToDonViCongTacDtoList(this IEnumerable<DonViCongTacEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToDonViCongTacDto(mapper)).ToList();
    }
}
