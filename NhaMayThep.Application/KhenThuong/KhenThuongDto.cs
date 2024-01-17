using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.KhaiBaoTangLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong
{
    public class KhenThuongDto : IMapFrom<KhenThuongEntity>
    {
        public KhenThuongDto() { }

        public static KhenThuongDto Create(string Id, string MaSoNhanVien, string HinhThucKhenThuong, string LoaiKhenThuong, string TenDotKhenThuong, DateTime NgayKhenThuong, double TongGiaTri, string DonViApDung)
        {
            return new KhenThuongDto
            {
                Id = Id,
                MaSoNhanVien = MaSoNhanVien,
                HinhThucKhenThuong = HinhThucKhenThuong,
                LoaiKhenThuong = LoaiKhenThuong,
                TenDotKhenThuong = TenDotKhenThuong,
                NgayKhenThuong = NgayKhenThuong,
                TongGiaTri = TongGiaTri,
                DonViApDung = DonViApDung
            };
        }
        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public string HinhThucKhenThuong{  get; set; }
        public string LoaiKhenThuong { get; set; }
        public string TenDotKhenThuong { get; set; }
        public DateTime NgayKhenThuong { get; set; }
        public double TongGiaTri {  get; set; }
        public string DonViApDung { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<KhenThuongEntity, KhenThuongDto>();
        }
    }
}
