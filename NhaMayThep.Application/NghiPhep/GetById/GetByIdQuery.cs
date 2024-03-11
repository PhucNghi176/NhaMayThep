using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NghiPhep.GetById
{
    public class GetByIdQuery : IRequest<NghiPhepDto>, IQuery
    {
        public GetByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
