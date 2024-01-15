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
        public CreateChiTietDangVienCommand(string id, string dangVienId, int donViCongTacId, string chucVuDang, string trinhDoChinhTri, string nguoiTaoId)
        {
            ID = id;
            DangVienID = dangVienId;
            DonViCongTacID = donViCongTacId;
            ChucVuDang = chucVuDang;
            TrinhDoChinhTri = trinhDoChinhTri;
            NguoiTaoID = nguoiTaoId;
        }

        public string ID { get; set; }
        public string DangVienID { get; set; } //ThongTinDangVien
        public int DonViCongTacID { get; set; }

        public string ChucVuDang { get; set; }
        public string TrinhDoChinhTri { get; set; }

        public string? NguoiTaoID { get; set; }
    }
}
