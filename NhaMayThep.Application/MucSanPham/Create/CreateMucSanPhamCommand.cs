using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MucSanPham.Create
{
    public class CreateMucSanPhamCommand : IRequest<string>, ICommand
    {
        public CreateMucSanPhamCommand(string name, int mucSanPhamToiThieu, int mucSanPhamToiDa, decimal luongMucSanPham)
        {
            Name = name;
            MucSanPhamToiThieu = mucSanPhamToiThieu;
            MucSanPhamToiDa = mucSanPhamToiDa;
            LuongMucSanPham = luongMucSanPham;
        }
        public string Name { get; set; }
        public int MucSanPhamToiThieu { get; set; }
        public int MucSanPhamToiDa { get; set; }
        public decimal LuongMucSanPham { get; set; }
    }
}
