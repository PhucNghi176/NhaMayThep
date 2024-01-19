using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVu.GetChucVuById
{
    public class GetChucVuByIdQuery : IRequest<ChucVuDto>, IQuery
    {
        public int ID;
        public GetChucVuByIdQuery(int id)
        {
            ID = id;
        }
    }
}
