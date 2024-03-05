using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetByIdDeleted
{
    public class GetChiTietBaoHiemByIdDeletedQuery: IRequest<ChiTietBaoHiemDto>, IRequest
    {
        public GetChiTietBaoHiemByIdDeletedQuery(string id)
        {
            Id = id;
        }
        public GetChiTietBaoHiemByIdDeletedQuery() { }
        public string Id { get; set; }  
    }
}
