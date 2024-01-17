using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.Create
{
    public class CreateKyLuatCommand : IRequest<KyLuatDto>, ICommand
    {
        public string MaSoNhanVien {  get; set; }
        public string HinhThucKyLuat {  get; set; }
        public string LoaiKyLuat {  set; get; }
        public string TenDotKyLuat { set; get; }
        public DateTime NgayKiLuat { set; get; }
        public double TongPhat {  set; get; }
        public string DonViApDung { set; get; }

        public CreateKyLuatCommand(string maSoNhanVien, string hinhThucKyLuat, string loaiKyLuat, string tenDotKyLuat, DateTime ngayKiLuat, double tongPhat, string donViApDung)
        {
            MaSoNhanVien = maSoNhanVien;
            HinhThucKyLuat = hinhThucKyLuat;
            LoaiKyLuat = loaiKyLuat;
            TenDotKyLuat = tenDotKyLuat;
            NgayKiLuat = ngayKiLuat;
            TongPhat = tongPhat;
            DonViApDung = donViApDung;
        }
    }
}
