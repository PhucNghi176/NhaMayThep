using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.GetAll
{
    public class GetAllKyLuatQuery : IRequest<List<KyLuatDto>>, IQuery
    {
        public GetAllKyLuatQuery() { }
    }
}
