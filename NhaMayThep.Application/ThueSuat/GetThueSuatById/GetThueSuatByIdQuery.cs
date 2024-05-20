using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThueSuat.GetThueSuatById
{
    public class GetThueSuatByIdQuery : IRequest<ThueSuatDTO>, IQuery
    {
        public int ID { get; set; }
        public GetThueSuatByIdQuery(int iD)
        {
            ID = iD;
        }
        public GetThueSuatByIdQuery() { }
    }
}
