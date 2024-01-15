using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetThongTinCongDoan
{
    public class GetThongTinCongDoanQuery: IRequest<ThongTinCongDoanDto>, IQuery
    {
        public GetThongTinCongDoanQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
