using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.RestoreChiTietBaoHiem
{
    public class RestoreChiTietBaoHiemCommand: IRequest<string>, IRequest
    {
        public RestoreChiTietBaoHiemCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }  
    }
}
