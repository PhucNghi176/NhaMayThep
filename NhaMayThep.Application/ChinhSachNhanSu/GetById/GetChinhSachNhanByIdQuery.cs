using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.GetById
{
    public class GetChinhSachNhanByIdQuery : IRequest<ChinhSachNhanSuDto>, IQuery
    {
        public GetChinhSachNhanByIdQuery(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
