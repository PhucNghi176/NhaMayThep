﻿using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MaDangKiCaLamViec
{
    public class MaDangKiCaLamViecDTO : IMapFrom<MaDangKiCaLamEntity>
    {
        public MaDangKiCaLamViecDTO() { }

        public static MaDangKiCaLamViecDTO Create(int id, string name, DateTime thoiGianCaLamBatDau, DateTime thoiGianCaLamKetThuc)
        {
            return new MaDangKiCaLamViecDTO
            {
                Id = id,
                Name = name,
                ThoiGianCaLamBatDau = thoiGianCaLamBatDau,
                ThoiGianCaLamKetThuc = thoiGianCaLamKetThuc
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ThoiGianCaLamBatDau { get; set; }
        public DateTime ThoiGianCaLamKetThuc {  get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MaDangKiCaLamEntity, MaDangKiCaLamViecDTO>();
        }
    }
}