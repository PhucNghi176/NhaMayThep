using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HopDong.GetAllHopDongQuery
{
    public class GetAllHopDongQuery : IRequest<List<HopDongDto>>, IQuery
    {
        public GetAllHopDongQuery() { }
    }
}
