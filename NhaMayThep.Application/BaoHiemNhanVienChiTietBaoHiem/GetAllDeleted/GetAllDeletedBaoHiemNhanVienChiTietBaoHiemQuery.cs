using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAllDeleted
{
    public class GetAllDeletedBaoHiemNhanVienChiTietBaoHiemQuery : IRequest<List<BaoHiemNhanVienChiTietBaoHiemDto>>
    {
        public GetAllDeletedBaoHiemNhanVienChiTietBaoHiemQuery() { }
    }
}
