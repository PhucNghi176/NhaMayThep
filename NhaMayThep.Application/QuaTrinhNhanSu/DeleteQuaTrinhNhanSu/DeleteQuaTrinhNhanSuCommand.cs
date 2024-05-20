using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.QuaTrinhNhanSu.DeleteQuaTrinhNhanSu
{
    public class DeleteQuaTrinhNhanSuCommand : IRequest<string>, ICommand
    {
        public DeleteQuaTrinhNhanSuCommand(string id)
        {
            ID = id;
        }
        public string ID { get; set; }
    }
}
