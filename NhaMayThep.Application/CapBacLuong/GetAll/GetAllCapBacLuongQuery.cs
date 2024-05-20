using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.CapBacLuong.GetAll
{
    public class GetAllCapBacLuongQuery : IRequest<List<CapBacLuongDto>>, IQuery
    {
        public GetAllCapBacLuongQuery() { }
    }
}
