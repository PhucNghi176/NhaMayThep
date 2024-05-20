using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChiTietBaoHiem.CreateChiTietBaoHiem
{
    public class CreateChiTietBaoHiemCommand : IRequest<string>, ICommand
    {
        public CreateChiTietBaoHiemCommand(
            int loaibaohiem,
            DateTime ngayhieuluc,
            DateTime ngayketthuc,
            string noicap)
        {
            LoaiBaoHiem = loaibaohiem;
            NgayHieuLuc = ngayhieuluc;
            NgayKetThuc = ngayketthuc;
            NoiCap = noicap;
        }
        public int LoaiBaoHiem { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string NoiCap { get; set; }
    }
}
