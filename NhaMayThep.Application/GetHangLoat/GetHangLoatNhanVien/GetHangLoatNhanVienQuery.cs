using MediatR;

namespace NhaMayThep.Application.GetHangLoat.GetHangLoatNhanVien
{
    public class GetHangLoatNhanVienQuery : IRequest<Dictionary<string, List<KeyValuePair<int, string>>>>
    {
        public GetHangLoatNhanVienQuery()
        {

        }
    }
}
