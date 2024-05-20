using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KhaiBaoTangLuong.GetAll
{
    public class GetAllKhaiBaoTangLuongQuery : IRequest<List<KhaiBaoTangLuongDto>>, IQuery
    {
        public GetAllKhaiBaoTangLuongQuery()
        {

        }
    }
}