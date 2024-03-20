using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVien.GetAll
{
    public class GetAllQuery : IRequest<List<BaoHiemNhanVienDto>>, IQuery
    {
        public GetAllQuery() { }
    }
}
