using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetById
{
    public class GetThongTinCongDoanByIdQuery: IRequest<ThongTinCongDoanDto>, IQuery
    {
        public GetThongTinCongDoanByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
