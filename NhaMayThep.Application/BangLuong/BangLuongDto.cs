using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BangLuong
{
    public class BangLuongDto : IMapFrom<BangLuongEntity>
    {
        public BangLuongDto()
        {
        }

        public string ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public DateTime NgayKhaiBao { get; set; }
        public decimal LuongNghiPhep { get; set; }
        public decimal LuongTangCa { get; set; }
        public string KhenThuongID { get; set; }
        public string KyLuatID { get; set; }
        public decimal LuongCoBan { get; set; }
        public string PhuCapNhanVienID { get; set; }
        public decimal TongNhanCoDinh { get; set; }
        public double NgayCong { get; set; }
        public decimal TongThuNhap { get; set; }
        public decimal LuongDongBH { get; set; }
        public string BaoHiemNhanVienID { get; set; }
        public decimal TongBaoHiem { get; set; }
        public string PhuCapCongDoanID { get; set; }
        public string GiamTruNhanVienID { get; set; }
        public decimal TamUng { get; set; }
        public decimal LuongThucLanh { get; set; }
        public static BangLuongDto Create(string id, string maSoNhanVien, DateTime ngayKhaiBao, decimal luongNghiPhep, decimal luongTangCa, string khenThuongId, string kyLuatId, decimal luongCoBan,
                                          string phuCapNhanVienId, decimal tongNhanCoDinh, double ngayCong, decimal tongThuNhap, decimal luongDongBH, string baoHiemNhanVienId,decimal tongBaoHiem, string phuCapCongDoanId, 
                                          string giamTruNhanVienId, decimal tamUng, decimal luongThucLanh)
                                            
        {
            return new BangLuongDto
            {
                ID = id,
                MaSoNhanVien = maSoNhanVien,
                NgayKhaiBao = ngayKhaiBao,
                LuongNghiPhep = luongNghiPhep,
                LuongTangCa = luongTangCa,
                KhenThuongID = khenThuongId,
                KyLuatID = kyLuatId,
                LuongCoBan = luongCoBan,
                PhuCapNhanVienID = phuCapNhanVienId,
                TongNhanCoDinh = tongNhanCoDinh,
                NgayCong = ngayCong,
                TongThuNhap = tongThuNhap,
                LuongDongBH = luongDongBH,
                BaoHiemNhanVienID = baoHiemNhanVienId,
                TongBaoHiem = tongBaoHiem,
                PhuCapCongDoanID = phuCapCongDoanId,
                GiamTruNhanVienID = giamTruNhanVienId,
                TamUng = tamUng,
                LuongThucLanh = luongThucLanh
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BangLuongEntity, BangLuongDto>();
        }
    }
}
