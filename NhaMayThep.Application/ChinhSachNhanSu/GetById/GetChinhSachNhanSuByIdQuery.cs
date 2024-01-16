using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.GetById
{
    public class GetChinhSachNhanSuByIdQuery : IRequest<ChinhSachNhanSuDto>, IQuery
    {
        public int Id { get; set; }

        public GetChinhSachNhanSuByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
