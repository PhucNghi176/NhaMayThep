using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietDangVien.UpdateChiTietDangVien
{
    public class UpdateChiTietDangVienCommand : IRequest<ChiTietDangVienDto>, ICommand
    {
        public UpdateChiTietDangVienCommand(string nhanvienId, string dangVienId, int donViCongTacId, string chucVuDang, string trinhDoChinhTri )
        {
            NhanVienID = nhanvienId;
            DangVienID = dangVienId;
            DonViCongTacID = donViCongTacId;
            ChucVuDang = chucVuDang;
            TrinhDoChinhTri = trinhDoChinhTri;
        }

        public string NhanVienID { get; set; }
        public string DangVienID { get; set; } //ThongTinDangVien
        public int DonViCongTacID { get; set; }

        public string ChucVuDang { get; set; }
        public string TrinhDoChinhTri { get; set; }

    }
}
