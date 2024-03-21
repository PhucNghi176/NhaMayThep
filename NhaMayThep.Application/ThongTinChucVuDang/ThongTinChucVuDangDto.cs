﻿using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVuDang
{
    public class ThongTinChucVuDangDto : IMapFrom<ThongTinChucVuDangEntity>
    {
        public ThongTinChucVuDangDto() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public static ThongTinChucVuDangDto CreateThongTinChucVuDang(int id, string name)
        {
            return new ThongTinChucVuDangDto()
            {
                Id = id,
                Name = name
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinChucVuDangEntity, ThongTinChucVuDangDto>();
        }
    }
}
