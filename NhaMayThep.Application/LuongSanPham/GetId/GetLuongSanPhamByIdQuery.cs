using MediatR;
using NhaMayThep.Application.LuongCongNhat;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham.GetId
{
    public class GetLuongSanPhamByIDQuery : IRequest<LuongSanPhamDto>, ICommand
    {
        public string ID { get; set; }
        public GetLuongSanPhamByIDQuery(string iD)
        {
            ID = iD;
        }
        public GetLuongSanPhamByIDQuery() { }
    }
}
