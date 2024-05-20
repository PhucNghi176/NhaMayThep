using MediatR;

namespace NhaMayThep.Application.ThongTinDangVien.DeleteThongTinDangVien
{
    public class DeleteThongTinDangVienCommand : IRequest<string>
    {
        public DeleteThongTinDangVienCommand(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}
