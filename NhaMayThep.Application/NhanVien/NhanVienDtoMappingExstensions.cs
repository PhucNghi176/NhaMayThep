﻿using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.NhanVien
{
    public static class NhanVienDtoMappingExstensions
    {
        public static NhanVienDtoLogin MapToNhanVienDtoLogin(this NhanVienEntity entity, IMapper mapper)
            => mapper.Map<NhanVienDtoLogin>(entity);

        public static NhanVienDto MapToNhanVienDto(this NhanVienEntity entity, IMapper mapper)
            => mapper.Map<NhanVienDto>(entity);
    }
}

