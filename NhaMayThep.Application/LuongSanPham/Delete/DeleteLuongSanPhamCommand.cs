using MediatR;

namespace NhaMayThep.Application.LuongSanPham.Delete
{
    public class DeleteLuongSanPhamCommand : IRequest<string>
    {
        public DeleteLuongSanPhamCommand(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}