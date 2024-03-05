using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Functions
{

    public class ThueTNCNFunctions
    {
        private IThueSuatRepository _thueSuatRepository;

        public ThueTNCNFunctions(IThueSuatRepository thueSuatRepository)
        {
            _thueSuatRepository = thueSuatRepository;
        }
        public decimal TinhTongThuNhapTheoNam(decimal luongCoBan, decimal tangCa, decimal khenThuong, decimal luongNghiPhep)
        {
            decimal tongThuNhap = luongCoBan * 12 + (tangCa + khenThuong + luongNghiPhep);
            return tongThuNhap;
        }

        //Không có tổng thu nhập theo tháng

        public decimal TinhThuNhapTinhThueTheoNam(decimal thuNhapChiuThue, decimal tienGiamTruBanThan, int soNguoiPhuThuoc, decimal tienGiamTruNguoiPhuThuoc, decimal luongDongBaoHiem, decimal phiCongDoan)
        {
            decimal thuNhapTinhThue = thuNhapChiuThue - ((tienGiamTruBanThan * 12) + (soNguoiPhuThuoc * tienGiamTruNguoiPhuThuoc * 12) + luongDongBaoHiem * 12 + phiCongDoan * 12);
            return thuNhapTinhThue;
        }

        public decimal TinhThuNhapTinhThueTheoThang(decimal thuNhapChiuThue, decimal tienGiamTruBanThan, int soNguoiPhuThuoc, decimal tienGiamTruNguoiPhuThuoc, decimal luongDongBaoHiem, decimal phiCongDoan)
        {
            decimal thuNhapTinhThue = thuNhapChiuThue - (tienGiamTruBanThan + (soNguoiPhuThuoc * tienGiamTruNguoiPhuThuoc) + luongDongBaoHiem + phiCongDoan);
            return thuNhapTinhThue;
        }

        public decimal TinhThueTNCNPhaiNopTheoNam(decimal thuNhapTinhThue, List<ThueSuat> danhSachThueSuat) // truyền ThueSuat vào
        {
            decimal thueTNCNPhaiNop = 0;

            foreach (var thueSuat in danhSachThueSuat)
            {
                if (thuNhapTinhThue <= thueSuat.CuoiThueSuatTheoNam)
                {
                    thueTNCNPhaiNop += (thuNhapTinhThue - thueSuat.DauThueSuatTheoNam) * Convert.ToDecimal(thueSuat.PhanTramThueSuat);
                    break;
                }
                else
                {
                    thueTNCNPhaiNop += (thueSuat.CuoiThueSuatTheoNam - thueSuat.DauThueSuatTheoNam) * Convert.ToDecimal(thueSuat.PhanTramThueSuat);
                }
            }

            return thueTNCNPhaiNop;
        }
        public decimal TinhThueTNCNPhaiNopTheoThang(decimal thuNhapTinhThue, List<ThueSuat> danhSachThueSuat) // truyền ThueSuat vào
        {
            decimal thueTNCNPhaiNop = 0;

            foreach (var thueSuat in danhSachThueSuat)
            {
                if (thuNhapTinhThue <= thueSuat.CuoiThueSuatTheoThang)
                {
                    thueTNCNPhaiNop += (thuNhapTinhThue - thueSuat.DauThueSuatTheoThang) * Convert.ToDecimal(thueSuat.PhanTramThueSuat);
                    break;
                }
                else
                {
                    thueTNCNPhaiNop += (thueSuat.CuoiThueSuatTheoThang - thueSuat.DauThueSuatTheoThang) * Convert.ToDecimal(thueSuat.PhanTramThueSuat);
                }
            }

            return thueTNCNPhaiNop;
        }

        public void TinhThueTheoThang()
        {
            List<ThueSuat> danhSachThueSuat = TaoDuLieuThueSuat();
            var thuNhapTinhThue = 100000000;
            var thueTNCNPhaiNop = TinhThueTNCNPhaiNopTheoThang(thuNhapTinhThue, danhSachThueSuat);
            Console.WriteLine($"Thuế TNCN phải nộp: {thueTNCNPhaiNop}");
        }
        #region Test Data 

        //Cần sửa table theo attribute dưới đây
        public class ThueSuat
        {
            public int BacThue { get; set; }
            public decimal DauThueSuatTheoThang { get; set; }
            public decimal CuoiThueSuatTheoThang { get; set; }
            public decimal DauThueSuatTheoNam { get; set; }
            public decimal CuoiThueSuatTheoNam { get; set; }
            public double PhanTramThueSuat { get; set; }

            public ThueSuat(int bacThue, decimal dauThueSuatTheoThang, decimal cuoiThueSuatTheoThang, decimal dauThueSuatTheoNam, decimal cuoiThueSuatTheoNam, double phanTramThueSuat)
            {
                BacThue = bacThue;
                DauThueSuatTheoThang = dauThueSuatTheoThang;
                CuoiThueSuatTheoThang = cuoiThueSuatTheoThang;
                DauThueSuatTheoNam = dauThueSuatTheoNam;
                CuoiThueSuatTheoNam = cuoiThueSuatTheoNam;
                PhanTramThueSuat = phanTramThueSuat;
            }
        }
        static List<ThueSuat> TaoDuLieuThueSuat()
        {
            List<ThueSuat> danhSachThueSuat = new List<ThueSuat>
            {
                new ThueSuat(1, 0, 5000000, 0, 60000000, 0.05),
                new ThueSuat(2, 5000000, 10000000, 60000000, 120000000 , 0.1),
                new ThueSuat(3, 10000000, 18000000, 120000000, 216000000 , 0.15),
                new ThueSuat(4, 18000000, 32000000, 216000000, 384000000 , 0.2),
                new ThueSuat(5, 32000000, 52000000, 384000000, 624000000, 0.25),
                new ThueSuat(6, 52000000, 80000000, 624000000, 960000000, 0.3),
                new ThueSuat(7, 80000000, decimal.MaxValue, 960000000, decimal.MaxValue, 0.35)
            };

            return danhSachThueSuat;
        }
        #endregion
    }

}
