using MediatR;

namespace NhaMayThep.Application.TinhTrangLamViec.UpdateTinhTrangLamViec
{
    public class UpdateTinhTrangLamViecCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UpdateTinhTrangLamViecCommand() { }
        public UpdateTinhTrangLamViecCommand(int id, string name, string nguoiCapNhatID)
        {
            Id = id;
            Name = name;
        }
    }
}
