using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAll
{
    public class GetAllBaoHiemNhanVienChiTietBaoHiemQuery: IRequest<List<BaoHiemNhanVienChiTietBaoHiemDto>>
    {
        public GetAllBaoHiemNhanVienChiTietBaoHiemQuery() { }
    }
}
