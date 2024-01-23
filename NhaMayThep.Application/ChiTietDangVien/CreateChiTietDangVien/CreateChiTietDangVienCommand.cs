using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietDangVien.CreateChiTietDangVien
{
    public class CreateChiTietDangVienCommand : IRequest<string>, ICommand
    {
        public CreateChiTietDangVienCommand(string dangVienId, int donViCongTacId, string chucVuDang, string trinhDoChinhTri)
        {
            DangVienID = dangVienId;
            DonViCongTacID = donViCongTacId;
            ChucVuDang = chucVuDang;
            TrinhDoChinhTri = trinhDoChinhTri;
        }

        public string DangVienID { get; set; } //ThongTinDangVien
        public int DonViCongTacID { get; set; }

        public string ChucVuDang { get; set; }
        public string TrinhDoChinhTri { get; set; }

    }
}
