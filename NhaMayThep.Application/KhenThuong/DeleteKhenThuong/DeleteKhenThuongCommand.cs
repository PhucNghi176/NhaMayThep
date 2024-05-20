using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KhenThuong.DeleteKhenThuong
{
    public class DeleteKhenThuongCommand : IRequest<string>, ICommand
    {
        public string ID { get; set; }
        public DeleteKhenThuongCommand(string iD)
        {
            ID = iD;
        }
        public DeleteKhenThuongCommand() { }
    }
}
