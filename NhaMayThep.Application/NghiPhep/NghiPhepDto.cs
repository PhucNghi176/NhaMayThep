using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NhaMapThep.Application.Common.Mappings;

namespace NhaMayThep.Application.NghiPhep
{
    public class NghiPhepDto : IMapFrom<NghiPhepEntity>
    {
        public NghiPhepDto()
        {
        }

        public string ID { get; set; }
        public required string MaSoNhanVien { get; set; }
        public decimal LuongNghiPhep { get; set; }
        public decimal KhoanTruLuong { get; set; }
        public double SoGioNghiPhep { get; set; }
        public required int LoaiNghiPhepID { get; set; }

        public static NghiPhepDto Create(string id, string maSoNhanVien, decimal luongNghiPhep, decimal khoanTruLuong, double soGioNghiPhep, int loaiNghiPhepID)
        {
            return new NghiPhepDto
            {
                ID = id,
                MaSoNhanVien = maSoNhanVien,
                LuongNghiPhep = luongNghiPhep,
                KhoanTruLuong = khoanTruLuong,
                SoGioNghiPhep = soGioNghiPhep,
                LoaiNghiPhepID = loaiNghiPhepID
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NghiPhepEntity, NghiPhepDto>();
        }
    }
}
