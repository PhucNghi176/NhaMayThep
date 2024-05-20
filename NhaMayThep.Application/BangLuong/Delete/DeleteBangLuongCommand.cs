using MediatR;

namespace NhaMayThep.Application.BangLuong.Delete
{
    public class DeleteBangLuongCommand : IRequest<string>
    {
        public DeleteBangLuongCommand(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}
