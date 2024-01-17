using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhongBan.CreatePhongBan
{
    public class CreatePhongBanCommand : IRequest<PhongBanDto>, ICommand
    {
        public CreatePhongBanCommand(string name, int id)
        {
            Name = name;
            ID = id;
        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
