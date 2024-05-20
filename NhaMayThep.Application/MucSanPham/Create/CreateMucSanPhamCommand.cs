using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.MucSanPham.Create
{
    public class CreateMucSanPhamCommand : IRequest<string>, ICommand
    {
        public CreateMucSanPhamCommand(int mucSanPhamToiThieu, int mucSanPhamToiDa, decimal luongMucSanPham)
        {
            MucSanPhamToiThieu = mucSanPhamToiThieu;
            MucSanPhamToiDa = mucSanPhamToiDa;
            LuongMucSanPham = luongMucSanPham;
        }
        public int MucSanPhamToiThieu { get; set; }
        public int MucSanPhamToiDa { get; set; }
        public decimal LuongMucSanPham { get; set; }
    }
}
