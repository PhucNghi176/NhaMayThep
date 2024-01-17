using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinPhuCap.GetAllPhuCap
{
    public class GetAllPhuCapQuery : IRequest<List<PhuCapDto>>, IQuery
    {
        public GetAllPhuCapQuery()
        {

        }
    }
}
