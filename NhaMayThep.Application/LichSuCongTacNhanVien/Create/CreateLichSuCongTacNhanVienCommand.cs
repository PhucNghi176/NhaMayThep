using MediatR;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Create
{
    public class CreateLichSuCongTacNhanVienCommand : IRequest<LichSuCongTacNhanVienDto>
    {
        public CreateLichSuCongTacNhanVienCommand(string maSoNhanVien, int loaiCongTacID, DateTime ngayBatDau,
            DateTime ngayKetThuc, string noiCongTac, string lydo)
        {
            MaSoNhanVien = maSoNhanVien;
            LoaiCongTacID = loaiCongTacID;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            NoiCongTac = noiCongTac;
            LyDo = lydo;
        }

        public string MaSoNhanVien { get; set; }
        public int LoaiCongTacID { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string NoiCongTac { get; set; }
        public string LyDo { get; set; }
    }
}
