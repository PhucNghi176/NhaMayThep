using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiem.GetBaoHiemById
{
    public class GetBaoHiemByIdQuery : IRequest<BaoHiemDto>, IQuery
    {
        public int Id { get; set; }
        public GetBaoHiemByIdQuery(int id)
        {
            Id = id;
        }
    }
}
