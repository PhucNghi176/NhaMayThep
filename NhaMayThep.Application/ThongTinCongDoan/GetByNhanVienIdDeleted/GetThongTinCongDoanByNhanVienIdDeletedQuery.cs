using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByNhanVienIdDeleted
{
    public class GetThongTinCongDoanByNhanVienIdDeletedQuery: IRequest<ThongTinCongDoanDto>, IQuery
    {
        public GetThongTinCongDoanByNhanVienIdDeletedQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
