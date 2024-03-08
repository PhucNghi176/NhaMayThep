using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;

namespace NhaMayThep.Application.NghiPhep
{
    public class NghiPhepDto : IMapFrom<NghiPhepEntity>
    {
        public NghiPhepDto() { }
        public string ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public decimal LuongNghiPhep { get; set; }
        public decimal KhoanTruLuong { get; set; }
        public double SoGioNghiPhep { get; set; }
        public int LoaiNghiPhepID { get; set; }


        public static NghiPhepDto CreateNghiPhep(string Id ,string maSoNhanVien, decimal luongNghiPhep, decimal khoanTruLuong, double soGioNghiPhep, int loaiNghiPhepID)
        {
            return new NghiPhepDto()
            {
                ID = Id ,
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
