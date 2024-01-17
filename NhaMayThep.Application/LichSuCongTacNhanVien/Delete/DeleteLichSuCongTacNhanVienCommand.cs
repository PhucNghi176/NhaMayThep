using MediatR;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Delete
{
    public class DeleteLichSuCongTacNhanVienCommand : IRequest<string>
    {
        public DeleteLichSuCongTacNhanVienCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }

    }
}
