using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongSanPham.GetId
{
    public class GetLuongSanPhamByIdQuery : IRequest<LuongSanPhamDto>, ICommand
    {
        public string ID { get; set; }
        public GetLuongSanPhamByIdQuery(string iD)
        {
            ID = iD;
        }
        public GetLuongSanPhamByIdQuery() { }
    }
}
