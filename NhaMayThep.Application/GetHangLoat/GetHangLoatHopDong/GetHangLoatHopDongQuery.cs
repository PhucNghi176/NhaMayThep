using MediatR;

namespace NhaMayThep.Application.GetHangLoat.GetHangLoatHopDong
{
    public class GetHangLoatHopDongQuery : IRequest<Dictionary<string, List<KeyValuePair<int, string>>>>
    {
        public GetHangLoatHopDongQuery()
        {

        }
    }
}
