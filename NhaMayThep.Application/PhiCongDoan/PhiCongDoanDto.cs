using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhiCongDoan
{
    public class PhiCongDoanDto : IMapFrom<PhiCongDoanEntity>
    {
        public PhiCongDoanDto()
        {
        }

        public string ID { get; set; }
        public required string MaSoNhanVien { get; set; }
        public double PhanTramLuongDongBH { get; set; }

        public decimal LuongDongBH { get; set; }

        public static PhiCongDoanDto Create(string id, string maSoNhanVien, double phanTramLuongDongBH, decimal luongDongBH)
        {
            return new PhiCongDoanDto
            {
                ID = id,
                MaSoNhanVien = maSoNhanVien,
                PhanTramLuongDongBH = phanTramLuongDongBH,
                LuongDongBH = luongDongBH,
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PhiCongDoanEntity, PhiCongDoanDto>();
        }
    }
}
