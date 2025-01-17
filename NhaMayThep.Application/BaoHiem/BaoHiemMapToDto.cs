﻿using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.BaoHiem
{
    public static class BaoHiemMapToDto
    {
        public static BaoHiemDto MapToBaoHiemDto(this NhaMapThep.Domain.Entities.ConfigTable.BaoHiemEntity baohiem, IMapper mapper)
            => mapper.Map<BaoHiemDto>(baohiem);

        public static List<BaoHiemDto> MapToListBaoHiemDto(this IEnumerable<BaoHiemEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToBaoHiemDto(mapper)).ToList();
    }
}
