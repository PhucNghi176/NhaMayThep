using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.GetById
{
    public class GetKhaiBaoTangLuongByIdQuery : IRequest<KhaiBaoTangLuongDto>, IQuery
    {
        public GetKhaiBaoTangLuongByIdQuery(Guid Id)
        {
            this.Id = Id.ToString();
        }
        public string Id { get; set; }
    }
}
