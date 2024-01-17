using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhongBan.GetSinglePhongBan
{
    public class GetPhongBanQuery : IRequest<PhongBanDto>, IQuery
    {
        public GetPhongBanQuery(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
