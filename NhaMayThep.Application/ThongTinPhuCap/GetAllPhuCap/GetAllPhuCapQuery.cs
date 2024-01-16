using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.GetAllPhuCap
{
    public class GetAllPhuCapQuery : IRequest<List<PhuCapDto>>, IQuery
    {
        public GetAllPhuCapQuery()
        {
            
        }
    }
}
