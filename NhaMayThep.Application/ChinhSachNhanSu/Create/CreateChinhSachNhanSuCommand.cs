using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChinhSachNhanSu.Create
{
    public class CreateChinhSachNhanSuCommand : IRequest<string>, ICommand
    {
        public CreateChinhSachNhanSuCommand(string name, string mucDo, DateTime ngayHieuLuc, string noiDung)
        {
            Name = name;
            MucDo = mucDo;
            NgayHieuLuc = ngayHieuLuc;
            NoiDung = noiDung;
        }
        public string Name { get; set; }
        public string MucDo { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public string? NoiDung { get; set; }
    }
}
