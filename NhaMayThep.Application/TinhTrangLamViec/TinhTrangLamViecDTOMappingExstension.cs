﻿using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.ThongTinGiamTru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec
{
    public static class TinhTrangLamViecDTOMappingExstension
    {
        public static TinhTrangLamViecDTO MapToTinhTrangLamViecDTO(this TinhTrangLamViecEntity projectFrom, IMapper mapper)
           => mapper.Map<TinhTrangLamViecDTO>(projectFrom);

        public static List<TinhTrangLamViecDTO> MapToTinhTrangLamViecDTOList(this IEnumerable<TinhTrangLamViecEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToTinhTrangLamViecDTO(mapper)).ToList();
    }
}