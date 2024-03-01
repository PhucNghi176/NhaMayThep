using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.DeleteChiTietBaoHiem
{
    public class DeleteChiTietBaoHiemCommand: IRequest<string>, IRequest
    {
        public DeleteChiTietBaoHiemCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
