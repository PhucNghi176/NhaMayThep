using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHopDong
{
    public static class LoaiHopDongMapToDto
    {
        public static LoaiHopDongDto MapToLoaiHopDongDto(this NhaMapThep.Domain.Entities.ConfigTable.LoaiHopDongEntity loaiHopDong, IMapper mapper) 
            => mapper.Map<LoaiHopDongDto>(loaiHopDong);
    }
}
