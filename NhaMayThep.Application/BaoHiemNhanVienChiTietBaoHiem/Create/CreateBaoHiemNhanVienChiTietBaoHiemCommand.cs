using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Create
{
    public class CreateBaoHiemNhanVienChiTietBaoHiemCommand: IRequest<string>
    {
        public string MaCTBH { get;set; }
        public int MaBHNV { get;set; }
        public CreateBaoHiemNhanVienChiTietBaoHiemCommand(string mactbh, int mabhnv)
        {
            MaCTBH = mactbh;
            MaBHNV = mabhnv;
        }
    }
}
