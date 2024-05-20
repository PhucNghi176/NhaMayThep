using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongCongNhat.GetAll
{
    public class GetAllQuery : IRequest<List<LuongCongNhatDto>>, IQuery
    {

    }
}
