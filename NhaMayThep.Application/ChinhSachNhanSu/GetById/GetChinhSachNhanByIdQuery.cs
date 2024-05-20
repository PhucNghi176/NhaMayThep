using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChinhSachNhanSu.GetById
{
    public class GetChinhSachNhanByIdQuery : IRequest<ChinhSachNhanSuDto>, IQuery
    {
        public GetChinhSachNhanByIdQuery(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
