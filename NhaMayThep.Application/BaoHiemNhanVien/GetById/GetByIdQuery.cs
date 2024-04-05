using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVien.GetById
{
    public class GetByIdQuery : IRequest<BaoHiemNhanVienDto>, IQuery
    {
        public GetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
