using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BangLuong.GetAll
{
    public class GetAllQuery : IRequest<List<BangLuongDto>>, IQuery
    {

    }
}
