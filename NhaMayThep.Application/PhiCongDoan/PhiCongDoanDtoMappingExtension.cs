﻿using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.PhiCongDoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhiCongDoan
{
    public static class PhiCongDoanDtoMappingExtension
    {
        public static PhiCongDoanDto MapToPhiCongDoanDto(this PhiCongDoanEntity projectfrom, IMapper mapper)
        {
            return mapper.Map<PhiCongDoanDto>(projectfrom);

        }
        public static List<PhiCongDoanDto> MapToPhiCongDoanDtoList(this IEnumerable<PhiCongDoanEntity> projectFrom, IMapper mapper)
           => projectFrom.Select(x => x.MapToPhiCongDoanDto(mapper)).ToList();
    }
}
