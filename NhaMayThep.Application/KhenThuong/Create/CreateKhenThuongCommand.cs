using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.Create
{
    public class CreateKhenThuongCommand : IRequest<KhenThuongDto>, ICommand
    {
        public string MaSoNhanVien { get; set; }
        public string HinhThucKhenThuong { get; set; }
        public string LoaiKhenThuong { get; set; }
        public string TenDotKhenThuong { get; set; }
        public DateTime NgayKhenThuong { get; set; }
        public double TongGiaTri { get; set; }
        public string DonViApDung { get; set; }

        public CreateKhenThuongCommand(string maSoNhanVien, string hinhThucKhenThuong, string loaiKhenThuong, string tenDotKhenThuong, DateTime ngayKhenThuong, double tongGiaTri, string donViApDung)
        {
            MaSoNhanVien = maSoNhanVien;
            HinhThucKhenThuong = hinhThucKhenThuong;
            LoaiKhenThuong = loaiKhenThuong;
            TenDotKhenThuong = tenDotKhenThuong;
            NgayKhenThuong = ngayKhenThuong;
            TongGiaTri = tongGiaTri;
            DonViApDung = donViApDung;
        }
    }
}
