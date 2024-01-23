using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Update
{
    public class UpdateLichSuCongTacNhanVienCommand : IRequest<string>, ICommand
    {
        public string ID { get; set; }
        public int LoaiCongTacID { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string NoiCongTac { get; set; }
        public string LyDo { get; set; }

        public UpdateLichSuCongTacNhanVienCommand(string id, int lct, DateTime bd, DateTime kt, string nct, string ld)
        {
            ID = id;
            LoaiCongTacID = lct;
            NgayBatDau = bd;
            NgayKetThuc = kt;
            NoiCongTac = nct;
            LyDo = ld;
        }

        public UpdateLichSuCongTacNhanVienCommand()
        {

        }
    }
}
