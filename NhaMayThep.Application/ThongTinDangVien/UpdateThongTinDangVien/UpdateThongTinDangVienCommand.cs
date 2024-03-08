using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien
{
    public class UpdateThongTinDangVienCommand : IRequest<string>, ICommand
    {
        public UpdateThongTinDangVienCommand(string nhanVienId, int donViCongTacId, string chucVuDang, string trinhDoChinhTri, DateTime ngayVaoDang, string capDangVien)
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
        public string ChucVuDang { get; set; }
        public string TrinhDoChinhTri { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public string CapDangVien { get; set; }
    }
}
