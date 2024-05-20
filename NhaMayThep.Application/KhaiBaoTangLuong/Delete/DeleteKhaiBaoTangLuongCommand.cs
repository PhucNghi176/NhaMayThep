using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Delete
{
    public class DeleteKhaiBaoTangLuongCommand : IRequest<string>, ICommand
    {
        public string ID { get; set; }
        public DeleteKhaiBaoTangLuongCommand(string iD)
        {
            ID = iD;
        }
        public DeleteKhaiBaoTangLuongCommand() { }
    }
}
