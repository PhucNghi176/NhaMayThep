using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucDanh.GetAllChucDanh
{
    public class GetAllChucDanhQuery : IRequest<List<ChucDanhDto>>, IQuery
    {
        public GetAllChucDanhQuery()
        {
            
        }
    }
}
