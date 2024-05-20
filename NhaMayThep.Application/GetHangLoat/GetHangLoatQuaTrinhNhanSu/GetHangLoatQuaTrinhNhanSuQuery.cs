using MediatR;

namespace NhaMayThep.Application.GetHangLoat.GetHangLoatQuaTrinhNhanSu
{
    public class GetHangLoatQuaTrinhNhanSuQuery : IRequest<Dictionary<string, List<KeyValuePair<int, string>>>>
    {
        public GetHangLoatQuaTrinhNhanSuQuery()
        {

        }
    }
}
