﻿using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVu
{
    public class ChucVuDto :IMapFrom<ThongTinChucVuEntity>
    {
        public ChucVuDto() { }
        public static ChucVuDto Create(int id, string name)
        {
            return new ChucVuDto()
            {
                ID = id,
                Name = name,
            };
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinChucVuEntity, ChucVuDto>();
        }
    }
}
