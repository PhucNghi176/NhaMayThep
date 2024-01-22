using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiHoaDon.GetAll
{
    public class GetAllLoaiHoaDonQuerry : IRequest<List<LoaiHoaDonDto>>, IQuery
    {
        public GetAllLoaiHoaDonQuerry() { }
    }
}
