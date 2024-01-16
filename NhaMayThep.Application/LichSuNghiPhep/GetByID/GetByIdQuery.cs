using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.GetByID
{
    public class GetByIdQuery : IRequest<LichSuNghiPhepDto>
    {
        public string Id { get; set; }

        public GetByIdQuery(string id)
        {
            Id = id;
        }
    }
}