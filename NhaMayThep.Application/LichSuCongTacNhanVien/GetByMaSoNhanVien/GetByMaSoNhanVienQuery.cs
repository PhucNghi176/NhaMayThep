using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.GetByMaSoNhanVien
{
    public class GetByMaSoNhanVienQuery : IRequest<List<LichSuCongTacNhanVienDto>>
    {
        public GetByMaSoNhanVienQuery() { }

        public GetByMaSoNhanVienQuery(string maSoNhanVien)
        {
            MaSoNhanVien = maSoNhanVien;
        }

        public string MaSoNhanVien {  get; set; }
    }
}
