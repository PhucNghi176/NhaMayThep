using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongTy.GetAllThongTinCongTy
{
    public class GetAllThongTinCongTyQuery : IRequest<List<ThongTinCongTyDto>>, IQuery
    {
        public GetAllThongTinCongTyQuery()
        {
        }
    }
}