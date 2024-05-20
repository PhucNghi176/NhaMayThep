using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.CreateThongTinTrinhDoChinhTri
{
    public class CreateThongTinTrinhDoChinhTriCommand : IRequest<string>, ICommand
    {
        public string TenTrinhDoChinhTri { get; set; }
        public CreateThongTinTrinhDoChinhTriCommand(string tenTrinhDoChinhTri)
        {
            TenTrinhDoChinhTri = tenTrinhDoChinhTri;
        }
    }
}
