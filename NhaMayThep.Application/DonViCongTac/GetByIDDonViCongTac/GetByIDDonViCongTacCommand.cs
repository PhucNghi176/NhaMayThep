using MediatR;

namespace NhaMayThep.Application.DonViCongTac.GetByIDDonViCongTac
{
    public class GetByIDDonViCongTacCommand : IRequest<DonViCongTacDto>
    {
        public GetByIDDonViCongTacCommand(int id)
        {
            ID = id;
        }

        public int ID { get; set; }

    }
}
