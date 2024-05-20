using MediatR;

namespace NhaMayThep.Application.ThongTinCapDangVien.UpdateThongTinCapDangVien
{
    public class UpdateThongTinCapDangVienCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string TenCapDangVien { get; set; }
        public UpdateThongTinCapDangVienCommand(int id, string tenCapDangVien)
        {
            Id = id;
            TenCapDangVien = tenCapDangVien;
        }
    }
}
