using MediatR;

namespace NhaMayThep.Application.DonViCongTac.DeleteDonViCongTac
{
    public class DeleteDonViCongTacCommand : IRequest<string>
    {
        public DeleteDonViCongTacCommand(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
