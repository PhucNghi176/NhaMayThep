using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.MucSanPham.Delete
{
    public class DeleteMucSanPhamCommand : IRequest<string>, ICommand
    {
        public DeleteMucSanPhamCommand(string id)
        {
            ID = id;
        }
        public string ID { get; set; }
    }
}
