using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhongBan.CreatePhongBan
{
    public class CreatePhongBanCommand : IRequest<bool>, ICommand
    {
        public CreatePhongBanCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
