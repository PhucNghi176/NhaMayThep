using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.UpdateThongTinQuaTrinhNhanSu
{
    public class UpdateThongTinQuaTrinhNhanSuCommand : IRequest<string>, ICommand
    {
        public UpdateThongTinQuaTrinhNhanSuCommand(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
