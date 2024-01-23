using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiem.GetAllBaoHiem
{
    public class GetAllBaoHiemQuery : IRequest<List<BaoHiemDto>>, IQuery
    {
        public GetAllBaoHiemQuery() { }
    }
}
