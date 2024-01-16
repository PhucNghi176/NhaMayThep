using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVu.GetAllChucVu
{
    public class GetAllChucVuQuery : IRequest<List<ChucVuDto>>, IQuery
    {
        public GetAllChucVuQuery()
        {
            
        }
    }
}
