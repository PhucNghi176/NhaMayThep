using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LuongSanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham.GetAll
{
    public class GetAllLuongSanPhamQuery : IRequest<List<LuongSanPhamDto>>, IQuery
    {
        public GetAllLuongSanPhamQuery()
        {

        }
    }
}
