using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThueSuat.DeleteThueSuat
{
    public class DeleteThueSuatCommand : IRequest<string>, ICommand
    {
        public int ID { get; set; }
        public DeleteThueSuatCommand(int iD)
        {
            ID = iD;
        }
        public DeleteThueSuatCommand() { }
    }
}
