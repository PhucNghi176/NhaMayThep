using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.GetById
{
    public class GetLnpByIdQuery : IRequest<LoaiNghiPhepDto>,IQuery
    {
        public int id;
        public GetLnpByIdQuery(int id ) {
            this.id = id;
        }

    }
}
