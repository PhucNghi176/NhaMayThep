using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetById
{
    public class GetChiTietBaoHiemByIdQuery: IRequest<ChiTietBaoHiemDto>, IRequest
    {
        public GetChiTietBaoHiemByIdQuery() { }
        public GetChiTietBaoHiemByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get;set; }
    }
}
