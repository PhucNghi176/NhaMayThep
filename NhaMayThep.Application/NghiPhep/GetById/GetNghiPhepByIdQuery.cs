using MediatR;
using NhaMayThep.Application.NghiPhep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NghiPhep.GetById
{
    public class GetNghiPhepByIdQuery : IRequest<NghiPhepDto>, ICommand
    {
        public string ID { get; set; }
        public GetNghiPhepByIdQuery(string iD)
        {
            ID = iD;
        }
        public GetNghiPhepByIdQuery() { }
    }
}
