using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetAll
{
    public class GetAllThongTinCongDoanQuery: IRequest<List<ThongTinCongDoanDto>>, IQuery
    {
        public GetAllThongTinCongDoanQuery() { }
    }
}
