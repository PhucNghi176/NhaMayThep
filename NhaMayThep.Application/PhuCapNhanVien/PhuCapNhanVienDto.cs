using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhuCapNhanVien
{
    public class PhuCapNhanVienDto : IMapFrom<PhuCapNhanVienEntity>
    {
        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public int PhuCap { get; set; }

        public static PhuCapNhanVienDto CreatePhuCapNhanVien(
            string id,
            string maSoNhanVien,
            int phuCap)
        {
            return new PhuCapNhanVienDto()
            {
                Id = id,
                MaSoNhanVien = maSoNhanVien,
                PhuCap = phuCap
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PhuCapNhanVienEntity, PhuCapNhanVienDto>();
        }
    }
}
