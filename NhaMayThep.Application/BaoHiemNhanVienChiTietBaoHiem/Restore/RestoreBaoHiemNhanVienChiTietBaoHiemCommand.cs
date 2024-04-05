using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Restore
{
    public class RestoreBaoHiemNhanVienChiTietBaoHiemCommand: IRequest<string>
    {
        public string MaCTBH { get; set; }
        public int MaBHNV { get; set; }
        public RestoreBaoHiemNhanVienChiTietBaoHiemCommand(string maCTBH, int maBHNV)
        {
            MaCTBH = maCTBH;
            MaBHNV = maBHNV;
        }
    }
}
