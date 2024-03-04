using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetAll
{
    public class GetAllChiTietBaoHiemQuery: IRequest<List<ChiTietBaoHiemDto>>, IRequest
    {
        public GetAllChiTietBaoHiemQuery() { }
    }
}
