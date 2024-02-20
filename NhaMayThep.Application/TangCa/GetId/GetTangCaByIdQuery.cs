using MediatR;
using NhaMayThep.Application.TangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TangCa.GetId
{
    public class GetTangCaByIdQuery : IRequest<TangCaDto>, ICommand
    {
        public string ID { get; set; }
        public GetTangCaByIdQuery(string iD)
        {
            ID = iD;
        }
        public GetTangCaByIdQuery() { }
    }
}
