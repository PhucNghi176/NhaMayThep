using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHopDong.GetAllLoaiHopDong
{
    public class GetAllLoaiHopDongQuery : IRequest<List<LoaiHopDongDto>>, IQuery
    {
        public GetAllLoaiHopDongQuery() { }
    }
}
