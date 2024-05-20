using MediatR;

namespace NhaMayThep.Application.ChiTietBaoHiem.UpdateChiTietBaoHiem
{
    public class UpdateChiTietBaoHiemCommand : IRequest<string>, IRequest
    {
        public UpdateChiTietBaoHiemCommand(
            string id,
            string? masonhanvien,
            int? loaibaohiem,
            DateTime? ngayhieuluc,
            DateTime? ngayketthuc,
            string? noicap)
        {
            Id = id;
            MaSoNhanVien = masonhanvien;
            LoaiBaoHiem = loaibaohiem;
            NgayHieuLuc = ngayhieuluc;
            NgayKetThuc = ngayketthuc;
            NoiCap = noicap;
        }
        public string? Id { get; set; }
        public string? MaSoNhanVien { get; set; }
        public int? LoaiBaoHiem { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string? NoiCap { get; set; }
    }
}
