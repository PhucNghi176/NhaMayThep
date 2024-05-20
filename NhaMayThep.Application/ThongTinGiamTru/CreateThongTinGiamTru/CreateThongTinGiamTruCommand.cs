using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTru.CreateThongTinGiamTru
{
    public class CreateThongTinGiamTruCommand : IRequest<string>, ICommand
    {
        public string Name { get; set; }
        public decimal SoTienGiamTru { get; set; }
        public CreateThongTinGiamTruCommand() { }
        public CreateThongTinGiamTruCommand(string name, decimal soTienGiamTru)
        {
            this.Name = name;
            this.SoTienGiamTru = soTienGiamTru;
        }
    }
}
