using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucVu.GetAllChucVu
{
    public class GetAllChucVuQuery : IRequest<List<ChucVuDto>>, IQuery
    {
        public GetAllChucVuQuery()
        {

        }
    }
}
