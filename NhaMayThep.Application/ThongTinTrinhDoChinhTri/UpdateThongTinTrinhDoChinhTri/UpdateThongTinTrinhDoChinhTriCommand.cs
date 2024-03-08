using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.UpdateThongTinTrinhDoChinhTri
{
    public class UpdateThongTinTrinhDoChinhTriCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string TenTrinhDoChinhTri { get; set; }
        public int TrinhDoChinhTri { get; set; }
        public UpdateThongTinTrinhDoChinhTriCommand(int id, string tenTrinhDoChinhTri, int trinhDoChinhTri)
        {
            Id = id;
            TenTrinhDoChinhTri = tenTrinhDoChinhTri;
            TrinhDoChinhTri = trinhDoChinhTri;
        }
    }
}
