using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BangLuong.GetById
{
    public class GetBangLuongByIdQuery : IRequest<BangLuongDto>, ICommand
    {
        public string ID { get; set; }
        public GetBangLuongByIdQuery(string iD)
        {
            ID = iD;
        }
        public GetBangLuongByIdQuery() { }
    }
}
