using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HopDong.GetHopDongByIdQuery
{
    public class GetHopDongByIdQuery : IRequest<HopDongDto>, IQuery
    {
        public string Id { get; set; }
        public GetHopDongByIdQuery(string id)
        {
            Id = id;
        }
    }
}
