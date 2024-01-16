using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep
{
    public class ChiTietNgayNghiPhepDto : IMapFrom<ChiTietNgayNghiPhepEntity>
    {
        public string MaSoNhanVien { get; set; }
        // In ChiTietNgayNghiPhepDto, UpdateChiTietNghiPhepCommand, and CreateChiTietNgayNghiPhepCommand:
        public double TongSoGio { get; set; }
        public double SoGioDaNghiPhep { get; set; }
        public double SoGioConLai { get; set; }
        public int NamHieuLuc { get; set; } // Note the name change from NamHieuLuoc to NamHieuLuc
        public int LoaiNghiPhepID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChiTietNgayNghiPhepEntity, ChiTietNgayNghiPhepDto>();

        }
    }
}
