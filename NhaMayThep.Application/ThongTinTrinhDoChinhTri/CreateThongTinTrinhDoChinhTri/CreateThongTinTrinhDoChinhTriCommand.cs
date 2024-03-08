using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.CreateThongTinTrinhDoChinhTri
{
    public class CreateThongTinTrinhDoChinhTriCommand : IRequest<string>, ICommand
    {
        public string TenTrinhDoChinhTri { get; set; }
        public int TrinhDoChinhTri { get; set; }
        public CreateThongTinTrinhDoChinhTriCommand(string tenTrinhDoChinhTri, int trinhDoChinhTri)
        {
            TenTrinhDoChinhTri = tenTrinhDoChinhTri;
            TrinhDoChinhTri = trinhDoChinhTri;
        }
    }
}
