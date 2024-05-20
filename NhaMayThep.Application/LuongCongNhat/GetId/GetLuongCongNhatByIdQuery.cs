using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongCongNhat.GetId
{
    public class GetLuongCongNhatByIdQuery : IRequest<LuongCongNhatDto>, ICommand
    {
        public string ID { get; set; }
        public GetLuongCongNhatByIdQuery(string iD)
        {
            ID = iD;
        }
        public GetLuongCongNhatByIdQuery() { }
    }
}
