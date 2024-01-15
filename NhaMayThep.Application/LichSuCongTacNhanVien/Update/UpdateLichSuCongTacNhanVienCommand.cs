using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Update
{
    public class UpdateLichSuCongTacNhanVienCommand : IRequest<LichSuCongTacNhanVienDto>
    {
        public UpdateLichSuCongTacNhanVienCommand(string id, string maSoNhanVien, int loaiCongTacID, DateTime ngayBatDau,
       DateTime ngayKetThuc, string noiCongTac, string lydo)
        {
            Id = id;
            MaSoNhanVien = maSoNhanVien;
            LoaiCongTacID = loaiCongTacID;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            NoiCongTac = noiCongTac;
            LyDo = lydo;
        }

        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public int LoaiCongTacID { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string NoiCongTac { get; set; }
        public string LyDo { get; set; }
    }
}
