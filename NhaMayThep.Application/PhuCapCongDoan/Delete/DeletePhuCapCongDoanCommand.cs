using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhuCapCongDoan.Delete
{
    public class DeletePhuCapCongDoanCommand : IRequest<string>, ICommand
    {
        public DeletePhuCapCongDoanCommand(string id)
        {
            ID = id;
        }
        public string ID { get; set; }
    }
}
