using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.QuaTrinhNhanSu.GetSingleQuaTrinhNhanSu
{
    public class GetQuaTrinhNhanSuQuery : IRequest<QuaTrinhNhanSuDto?>, IQuery
    {
        public GetQuaTrinhNhanSuQuery(string id)
        {
            ID = id;
        }
        public string ID { get; set; }
    }
}
