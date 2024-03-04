using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetAllDeleted
{
    public class GetAllDeletedChiTietBaoHiemQuery: IRequest<List<ChiTietBaoHiemDto>>, IRequest
    {
        public GetAllDeletedChiTietBaoHiemQuery() { }
    }
}
