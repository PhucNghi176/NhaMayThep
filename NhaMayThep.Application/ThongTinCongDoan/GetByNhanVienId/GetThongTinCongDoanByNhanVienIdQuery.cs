using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByNhanVienId
{
    public class GetThongTinCongDoanByNhanVienIdQuery: IRequest<ThongTinCongDoanDto>, IQuery
    {
        public GetThongTinCongDoanByNhanVienIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
