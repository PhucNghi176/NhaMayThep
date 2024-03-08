using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.GetAll
{
    public class GetAllThongTinTrinhDoChinhTriQuery : IRequest<List<ThongTinTrinhDoChinhTriDto>>, IQuery
    {
        public GetAllThongTinTrinhDoChinhTriQuery() { }
    }
}
