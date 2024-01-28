using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.UpdateNhanVien
{
    public class UpdateNhanVienCommand : IRequest<string>, ICommand
    {
        public UpdateNhanVienCommand() { }
        public UpdateNhanVienCommand(string id ,string email , string hoVaTen, int chucVuID, int tinhTrangLamViecID, DateTime ngayVaoCongTy, string diaChiLienLac, string soDienThoaiLienLac, string maSoThue, string tenNganHang, string soTaiKhoan, int? soNguoiPhuThuoc)
        {
            Id = id;
            Email = email;
            HoVaTen = hoVaTen;
            ChucVuID = chucVuID;
            TinhTrangLamViecID = tinhTrangLamViecID;
            NgayVaoCongTy = ngayVaoCongTy;
            DiaChiLienLac = diaChiLienLac;
            SoDienThoaiLienLac = soDienThoaiLienLac;
            MaSoThue = maSoThue;
            TenNganHang = tenNganHang;
            SoTaiKhoan = soTaiKhoan;
            SoNguoiPhuThuoc = soNguoiPhuThuoc;
        }
        public string Id { get; set; }
        public string Email { get; set; }
        public string HoVaTen { get; set; }
        public int? ChucVuID { get; set; }
        public int TinhTrangLamViecID { get; set; }
        public DateTime NgayVaoCongTy { get; set; }
        public string DiaChiLienLac { get; set; }
        public string SoDienThoaiLienLac { get; set; }
        public string MaSoThue { get; set; }
        public string TenNganHang { get; set; }
        public string SoTaiKhoan { get; set; }
        public int? SoNguoiPhuThuoc { get; set; }
    }
}
