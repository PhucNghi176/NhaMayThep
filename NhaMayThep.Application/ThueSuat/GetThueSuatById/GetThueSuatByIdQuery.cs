using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThueSuat.GetThueSuatById
{
    public class GetThueSuatByIdQuery : IRequest<ThueSuatDTO>, IQuery
    {
        public int ID { get; set; }
        public GetThueSuatByIdQuery(int iD)
        {
            ID = iD;
        }
        public GetThueSuatByIdQuery() { }
    }
}
