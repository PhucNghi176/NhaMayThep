using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.GetById
{
    public class GetLoaiNghiPhepByIdQuery : IRequest<LoaiNghiPhepDto>, IQuery
    {
        public int id;
        public GetLoaiNghiPhepByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
