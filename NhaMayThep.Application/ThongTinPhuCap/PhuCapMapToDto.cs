using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap
{
    public static class PhuCapMapToDto
    {
        public static PhuCapDto MapToPhuCapDto(this NhaMapThep.Domain.Entities.ConfigTable.ThongTinPhuCapEntity entity, IMapper mapper)
            => mapper.Map<PhuCapDto>(entity);
    }
}
