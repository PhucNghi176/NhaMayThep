using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinPhuCap.GetPhuCapById
{
    public class GetPhuCapByIdQuery : IRequest<PhuCapDto>, IQuery
    {
        public int ID;
        public GetPhuCapByIdQuery(int id)
        {
            ID = id;
        }
    }
}
