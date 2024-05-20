using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhiCongDoan.GetId
{
    public class GetPhiCongDoanByIdQuery : IRequest<PhiCongDoanDto>, ICommand
    {
        public string ID { get; set; }
        public GetPhiCongDoanByIdQuery(string iD)
        {
            ID = iD;
        }
        public GetPhiCongDoanByIdQuery() { }
    }
}
