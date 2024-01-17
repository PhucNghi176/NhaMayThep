using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.GetById
{
    public class GetKhenThuongByIdQuery : IRequest<KhenThuongDto>, IQuery
    {
        public string Id { get; set; }
        public GetKhenThuongByIdQuery(string id)
        {
            Id = id;
        }
    }
}
