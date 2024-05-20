using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KhenThuong.GetKhenThuongById
{
    public class GetKhenThuongByIDQuery : IRequest<KhenThuongDTO>, ICommand
    {
        public string ID { get; set; }
        public GetKhenThuongByIDQuery(string iD)
        {
            ID = iD;
        }
        public GetKhenThuongByIDQuery() { }
    }
}
