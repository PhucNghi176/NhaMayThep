using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HopDong
{
    public static class HopDongMapToDto
    {
        public static HopDongDto MapToHopDongDto(this NhaMapThep.Domain.Entities.HopDongEntity hopDong, IMapper mapper)
            => mapper.Map<HopDongDto>(hopDong); 
    }
}
