using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.GetSingleThongTinQuaTrinhNhanSu
{
    public class GetSingleThongTinQuaTrinhNhanSuQuery : IRequest<ThongTinQuaTrinhNhanSuDto>, IQuery
    {
        public GetSingleThongTinQuaTrinhNhanSuQuery(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
