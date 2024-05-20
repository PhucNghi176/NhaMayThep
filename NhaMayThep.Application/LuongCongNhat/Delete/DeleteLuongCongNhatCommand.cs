using MediatR;

namespace NhaMayThep.Application.LuongCongNhat.Delete
{
    public class DeleteLuongCongNhatCommand : IRequest<string>
    {
        public DeleteLuongCongNhatCommand(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}
