using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucDanh.GetChucDanhById
{
    public class GetChucDanhByIdQuery : IRequest<ChucDanhDto>, IQuery
    {
        public int ID;
        public GetChucDanhByIdQuery(int id)
        {
            ID = id;
        }
    }
}
