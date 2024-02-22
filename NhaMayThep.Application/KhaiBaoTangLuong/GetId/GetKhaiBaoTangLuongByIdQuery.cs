using MediatR;
using NhaMayThep.Application.KhaiBaoTangLuong;
using System;
using NhaMayThep.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.GetId
{
    public class GetKhaiBaoTangLuongByIdQuery : IRequest<KhaiBaoTangLuongDto>, ICommand
    {
        public string ID { get; set; }
        public GetKhaiBaoTangLuongByIdQuery(string iD)
        {
            ID = iD;
        }
        public GetKhaiBaoTangLuongByIdQuery() { }
    }
}
