using MediatR;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Delete
{
    public class DeleteBaoHiemNhanVienChiTietBaoHiemCommand: IRequest<string>
    {
        public string MaCTBH {  get; set; } 
        public int MaBHNV { get; set; }
        public DeleteBaoHiemNhanVienChiTietBaoHiemCommand(string maCTBH, int maBHNV)
        {
            MaCTBH = maCTBH;
            MaBHNV = maBHNV;
        }
    }
}
