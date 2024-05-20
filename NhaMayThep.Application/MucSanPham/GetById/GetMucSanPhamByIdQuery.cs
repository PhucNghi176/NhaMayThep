using MediatR;
using NhaMayThep.Application.Common.Interfaces;

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
