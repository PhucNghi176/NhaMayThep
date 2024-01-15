using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Update
{
    public class UpdateLichSuCongTacNhanVienCommand : IRequest, ICommand
    {
        public string Id { get; set; }
        public int LoaiCongTacID { get; set; }
        public DateTime BD { get; set; }
        public DateTime KT { get; set; }
        public string NoiCongTac {  get; set; }
        public string LyDo { get; set; }

        public UpdateLichSuCongTacNhanVienCommand(string id, int lct, DateTime bd, DateTime kt, string nct, string ld)
        {
            Id = id;
            LoaiCongTacID = lct;
            BD = bd;
            KT = kt;
            NoiCongTac = nct;
            LyDo = ld;
        }
    }
}
