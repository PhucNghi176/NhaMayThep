using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChinhSachNhanSu.GetAll
{
    public class GetAllChinhSachNhanSuQuery : IRequest<List<ChinhSachNhanSuDto>>, IQuery
    {
        public GetAllChinhSachNhanSuQuery()
        {

        }
    }
}
