using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.GetById
{
    public class GetKyLuatByIdQuery : IRequest<KyLuatDto>, IQuery
    { 
        public string Id { get; set; }
        public GetKyLuatByIdQuery(string id)
        {
            Id = id;
        }
    }
}
