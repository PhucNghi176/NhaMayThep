using MediatR;

namespace NhaMayThep.Application.HopDong.UpdateNgayKetThucHopDongCommand
{
    public class UpdateNgayKetThucHopDongCommand : IRequest<string>
    {
        public string Id { get; set; }

        public UpdateNgayKetThucHopDongCommand(string id)
        {
            Id = id;
        }

        public UpdateNgayKetThucHopDongCommand() { }
    }
}
