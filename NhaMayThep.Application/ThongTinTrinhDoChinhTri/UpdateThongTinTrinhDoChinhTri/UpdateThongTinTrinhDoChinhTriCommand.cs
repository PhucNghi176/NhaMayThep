using MediatR;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.UpdateThongTinTrinhDoChinhTri
{
    public class UpdateThongTinTrinhDoChinhTriCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string TenTrinhDoChinhTri { get; set; }
        public UpdateThongTinTrinhDoChinhTriCommand(int id, string tenTrinhDoChinhTri)
        {
            Id = id;
            TenTrinhDoChinhTri = tenTrinhDoChinhTri;
        }
    }
}
