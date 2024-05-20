using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.DeleteThongTinQuaTrinhNhanSu
{
    public class DeleteThongTinQuaTrinhNhanSuCommand : IRequest<string>, ICommand
    {
        public DeleteThongTinQuaTrinhNhanSuCommand(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
