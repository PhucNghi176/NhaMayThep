using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucVu.GetChucVuById
{
    public class GetChucVuByIdQuery : IRequest<ChucVuDto>, IQuery
    {
        public int ID;
        public GetChucVuByIdQuery(int id)
        {
            ID = id;
        }
    }
}
