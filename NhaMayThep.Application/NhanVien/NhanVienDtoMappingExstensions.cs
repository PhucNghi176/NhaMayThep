using AutoMapper;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien
{
    public static class NhanVienDtoMappingExstensions
    {
        public static NhanVienDto MapToNhanVienDto(this NhanVienEntity entity, IMapper mapper)
            => mapper.Map<NhanVienDto>(entity);
    }
}

