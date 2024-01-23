﻿using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.QuaTrinhNhanSu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu
{
    public class ThongTinQuaTrinhNhanSuDto : IMapFrom<ThongTinQuaTrinhNhanSuEntity>
    {
        public ThongTinQuaTrinhNhanSuDto()
        {
            
        }
        public int ID { get; set; } 
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinQuaTrinhNhanSuEntity, ThongTinQuaTrinhNhanSuDto>();
        }
    }
}