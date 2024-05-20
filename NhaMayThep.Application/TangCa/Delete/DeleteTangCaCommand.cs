using MediatR;

namespace NhaMayThep.Application.TangCa.Delete
{
    public class DeleteTangCaCommand : IRequest<string>
    {
        public DeleteTangCaCommand(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}
