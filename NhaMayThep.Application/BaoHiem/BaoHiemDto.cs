﻿using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiem
{
    public class BaoHiemDto : IMapFrom<BaoHiemEntity>
    {
        public BaoHiemDto() { }
        public string Name { get; set; }
        public double PhanTramKhauTru { get; set; }
        public static BaoHiemDto Create(string name, double phanTramKhauTru)
        {
            return new BaoHiemDto()
            {
                Name = name,
                PhanTramKhauTru = phanTramKhauTru
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BaoHiemEntity, BaoHiemDto>();
        }
    }
}
