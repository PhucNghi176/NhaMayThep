using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NhanVien.CreateNewNhanVienCommand
{
    public class CreateNewNhanVienCommand : IRequest<string>, ICommand
    {
        public CreateNewNhanVienCommand(string email/*, string password,*/ ,string hoVaTen, int chucVuID, int tinhTrangLamViecID, DateTime ngayVaoCongTy, string diaChiLienLac, string soDienThoaiLienLac, string maSoThue, string tenNganHang, string soTaiKhoan, int? soNguoiPhuThuoc)
        {
            Email = email;
           // Password = password;
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

        public string Email { get; set; }
      //  public string Password { get; set; }
        public string HoVaTen { get; set; }
        public int ChucVuID { get; set; }
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
