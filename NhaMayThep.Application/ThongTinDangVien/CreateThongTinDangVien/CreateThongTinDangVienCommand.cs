using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.CreateThongTinDangVien
{
    public class CreateThongTinDangVienCommand : IRequest<string>, ICommand
    {
        public CreateThongTinDangVienCommand(string nhanVienId, int donViCongTacId, int chucVuDang, int trinhDoChinhTri, DateTime ngayVaoDang, int capDangVien )
        {
            NhanVienID = nhanVienId;
            DonViCongTacID = donViCongTacId;
            ChucVuDang = chucVuDang;
            TrinhDoChinhTri = trinhDoChinhTri;
            NgayVaoDang = ngayVaoDang;
            CapDangVien = capDangVien;
        }

        public string NhanVienID { get; set; }
        public int DonViCongTacID { get; set; }
        public int ChucVuDang { get; set; }
        public int TrinhDoChinhTri { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public int CapDangVien { get; set; }


    }
}
