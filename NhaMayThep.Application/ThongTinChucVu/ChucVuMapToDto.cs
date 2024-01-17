using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVu
{
    public static class ChucVuMapToDto
    {
        public static ChucVuDto MapToChucVuDto(this NhaMapThep.Domain.Entities.ConfigTable.ThongTinChucVuEntity entity, IMapper mapper)
            => mapper.Map<ChucVuDto>(entity);
    }
}
