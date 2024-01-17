using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucDanh.GetAllChucDanh
{
    public class GetAllChucDanhQuery : IRequest<List<ChucDanhDto>>, IQuery
    {
        public GetAllChucDanhQuery()
        {

        }
    }
}
