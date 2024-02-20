using MediatR;
using NhaMayThep.Application.PhiCongDoan;
using System;
using System.Collections.Generic;
using NhaMayThep.Application.Common.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhiCongDoan.GetId
{
    public class GetPhiCongDoanByIdQuery : IRequest<PhiCongDoanDto>, ICommand
    {
        public string ID { get; set; }
        public GetPhiCongDoanByIdQuery(string iD)
        {
            ID = iD;
        }
        public GetPhiCongDoanByIdQuery() { }
    }
}
