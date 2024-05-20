using MediatR;

namespace NhaMayThep.Application.PhiCongDoan.Delete
{
    public class DeletePhiCongDoanCommand : IRequest<string>
    {
        public DeletePhiCongDoanCommand(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}
