using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.CreateThongTinQuaTrinhNhanSu
{
    public class CreateThongTinQuaTrinhNhanSuCommand : IRequest<string>, ICommand
    {
        public CreateThongTinQuaTrinhNhanSuCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
