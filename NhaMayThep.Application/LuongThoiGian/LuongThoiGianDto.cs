using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongThoiGian
{
    public class LuongThoiGianDto : IMapFrom<LuongThoiGianEntity>
    {
        public string Id {  get; set; }        
        public string MaSoNhanVien { get; set; }
        public int MaLuongThoiGian { get; set; }
        public decimal LuongNam {  get; set; }
        public decimal LuongThang { get; set; }
        public decimal LuongTuan { get; set; }
        public decimal LuongNgay { get; set; }
        public decimal LuongGio { get; set; }
        public DateTime NgayApDung { get; set; }

        public static LuongThoiGianDto CreateLuongThoiGian (
            string id,
            string maSoNhanVien,
            int maLuongThoiGian,
            decimal luongNam,
            decimal luongThang,
            decimal luongTuan,
            decimal luongNgay,
            decimal luongGio,
            DateTime ngayApDung)
        {
            return new LuongThoiGianDto()
            {
                Id = id,
                MaSoNhanVien = maSoNhanVien,
                MaLuongThoiGian = maLuongThoiGian,
                LuongNam = luongNam,
                LuongThang = luongThang,
                LuongNgay = luongNgay,
                LuongTuan = luongTuan,
                LuongGio = luongGio,
                NgayApDung = ngayApDung
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LuongThoiGianEntity, LuongThoiGianDto>();
        }
    }
}
