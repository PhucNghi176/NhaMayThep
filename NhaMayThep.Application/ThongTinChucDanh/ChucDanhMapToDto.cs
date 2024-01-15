using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucDanh
{
    public static class ChucDanhMapToDto
    {
        public static ChucDanhDto MapToChucDanhDto(this NhaMapThep.Domain.Entities.ConfigTable.ThongTinChucDanhEntity entity, IMapper mapper)
            => mapper.Map<ChucDanhDto>(entity);
    }
}
