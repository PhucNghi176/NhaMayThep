using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThueSuat.GetAllThueSuat
{
    public class GetAllThueSuatQuery : IRequest<List<ThueSuatDTO>>, IQuery
    {

    }
}
