using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChinhSachNhanSu.Delete
{
    public class DeleteChinhSachNhanSuCommand : IRequest<string>, ICommand
    {
        public DeleteChinhSachNhanSuCommand(int id)
        {

            ID = id;
        }
        public int ID { get; set; }
    }
}
