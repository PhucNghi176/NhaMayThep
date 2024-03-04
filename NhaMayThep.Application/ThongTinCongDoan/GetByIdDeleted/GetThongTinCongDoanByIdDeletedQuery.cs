using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByIdDeleted
{
    public class GetThongTinCongDoanByIdDeletedQuery: IRequest<ThongTinCongDoanDto>, IQuery
    {
        public GetThongTinCongDoanByIdDeletedQuery(string id)
        {
            Id = id;
        }
        public GetThongTinCongDoanByIdDeletedQuery() { }
        public string Id { get; set; }
    }
}
