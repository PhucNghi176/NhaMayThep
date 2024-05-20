using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TinhTrangLamViec.GetTinhTrangLamViecByID
{
    public class GetTinhTrangLamViecByIDQuery : IRequest<TinhTrangLamViecDTO>, IQuery
    {
        public int id { get; set; }
        public GetTinhTrangLamViecByIDQuery(int id)
        {
            this.id = id;
        }
    }
}
