using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Update
{
    public class UpdateKhaiBaoTangLuongCommand : IRequest<string>, ICommand
    {
        public required string MaSoNhanVien { get; set; }
        public float PhanTramTang { get; set; }
        public DateTime NgayApDung { get; set; }
        public string LyDo { get; set; }
        public string ID { get; set; }
        public UpdateKhaiBaoTangLuongCommand(string Id, string maSoNhanVien, float phanTramTang, DateTime ngayApDung, string lyDo)
        {
            ID = Id;
            MaSoNhanVien = maSoNhanVien;
            PhanTramTang = phanTramTang;
            NgayApDung = ngayApDung;
            LyDo = lyDo;
        }
        public UpdateKhaiBaoTangLuongCommand() { }
    }
}
