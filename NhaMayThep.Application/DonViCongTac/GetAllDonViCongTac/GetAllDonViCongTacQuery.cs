using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.DonViCongTac.GetAllDonViCongTac
{
    public class GetAllDonViCongTacQuery : IRequest<List<DonViCongTacDto>>, IQuery
    {
        public GetAllDonViCongTacQuery()
        {

        }

    }
}
