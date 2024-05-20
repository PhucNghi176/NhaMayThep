using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongThoiGian.GetAll
{
    public class GetAllLuongThoiGianQuery : IRequest<List<LuongThoiGianDto>>, IQuery
    {
        public GetAllLuongThoiGianQuery() { }
    }
}
