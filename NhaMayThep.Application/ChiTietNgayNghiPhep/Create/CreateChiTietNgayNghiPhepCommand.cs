using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Create
{
    public class CreateChiTietNgayNghiPhepCommand : IRequest<string>, ICommand
    {

        public string NhanVienID { get; set; }
        public int LoaiNghiPhepID { get; set; }
        public double TongSoGio { get; set; }
        public double SoGioDaNghiPhep { get; set; }
        public double SoGioConLai { get; set; }
        public int NamHieuLuc { get; set; }


        public CreateChiTietNgayNghiPhepCommand(string nhanVienId, int loaiNghiPhepID, double tongSoGio, double soGioDaNghiPhep, double soGioConLai, int namHieuLuc)
        {

            NhanVienID = nhanVienId;
            LoaiNghiPhepID = loaiNghiPhepID;
            TongSoGio = tongSoGio;
            SoGioDaNghiPhep = soGioDaNghiPhep;
            SoGioConLai = soGioConLai;
            NamHieuLuc = namHieuLuc;
        }
    }
}
