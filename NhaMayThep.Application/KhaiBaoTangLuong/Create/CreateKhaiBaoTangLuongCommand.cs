using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Create
{
    public class CreateKhaiBaoTangLuongCommand : IRequest<KhaiBaoTangLuongDto>, ICommand
    {
        public CreateKhaiBaoTangLuongCommand(Guid MaSoNhanVien, double PhanTramTang, DateTime NgayApDung, string LyDo)
        { 
            this.MaSoNhanVien = MaSoNhanVien.ToString();
            this.PhanTramTang = PhanTramTang;
            this.NgayApDung = NgayApDung;
            this.LyDo = LyDo;
        }
        public string MaSoNhanVien { get; set; }
        public double PhanTramTang { get; set; }
        public DateTime NgayApDung { get; set; }
        public string LyDo {  get; set; }
    }
}
