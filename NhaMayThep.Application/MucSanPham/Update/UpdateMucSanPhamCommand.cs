using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MucSanPham.Update
{
    public class UpdateMucSanPhamCommand : IRequest<string>, ICommand
    {
        public UpdateMucSanPhamCommand(int id, string name, int mucSanPhamToiThieu, int mucSanPhamToiDa, decimal luongMucSanPham)
        {
            ID = id;
            Name = name;
            MucSanPhamToiThieu = mucSanPhamToiThieu;
            MucSanPhamToiDa = mucSanPhamToiDa;
            LuongMucSanPham = luongMucSanPham;
        }
        public int ID {  get; set; }
        public string Name { get; set; }
        public int MucSanPhamToiThieu { get; set; }
        public int MucSanPhamToiDa { get; set; }
        public decimal LuongMucSanPham { get; set; }
    }
}
