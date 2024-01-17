using AutoMapper;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CanCuocCongDan
{
    public static class CanCuocCongDanMappingExstension
    {
        public static CanCuocCongDanDto MapToCanCuocCongDanDto(this CanCuocCongDanEntity entity, IMapper mapper)
       => mapper.Map<CanCuocCongDanDto>(entity);

    }
}
