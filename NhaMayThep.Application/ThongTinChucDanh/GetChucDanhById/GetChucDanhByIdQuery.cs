using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucDanh.GetChucDanhById
{
    public class GetChucDanhByIdQuery : IRequest<ChucDanhDto>, IQuery
    {
        public int ID;
        public GetChucDanhByIdQuery(int id)
        {
            ID = id;
        }
    }
}
