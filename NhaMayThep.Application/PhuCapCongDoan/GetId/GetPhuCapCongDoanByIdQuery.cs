using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhuCapCongDoan.GetId
{
    public class GetPhuCapCongDoanByIdQuery : IRequest<PhuCapCongDoanDto>, IQuery
    {
        public GetPhuCapCongDoanByIdQuery(string id)
        {
            ID = id;
        }
        public string ID { get; set; }
    }
}
