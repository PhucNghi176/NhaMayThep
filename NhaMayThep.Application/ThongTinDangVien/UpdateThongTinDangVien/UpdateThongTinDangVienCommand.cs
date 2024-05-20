using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien
{
    public class UpdateThongTinDangVienCommand : IRequest<string>, ICommand
    {
        public UpdateThongTinDangVienCommand(string id, int donViCongTacId, int chucVuDang, int trinhDoChinhTri, DateTime ngayVaoDang, int capDangVien)
        {
            ID = id;
            DonViCongTacID = donViCongTacId;
            ChucVuDang = chucVuDang;
            TrinhDoChinhTri = trinhDoChinhTri;
            NgayVaoDang = ngayVaoDang;
            CapDangVien = capDangVien;
        }

        public string ID { get; set; }
        public int DonViCongTacID { get; set; }
        public int ChucVuDang { get; set; }
        public int TrinhDoChinhTri { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public int CapDangVien { get; set; }
    }
}
