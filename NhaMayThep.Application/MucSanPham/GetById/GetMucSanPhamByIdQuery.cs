using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MucSanPham.GetById
{
    public class GetMucSanPhamByIdQuery : IRequest<MucSanPhamDto>, IQuery
    {
        public GetMucSanPhamByIdQuery(string id)
        {
            ID = id;
        }
        public string ID { get; set; }
    }
}
