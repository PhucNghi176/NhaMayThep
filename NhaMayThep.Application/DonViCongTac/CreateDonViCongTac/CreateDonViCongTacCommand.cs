using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.DonViCongTac.CreateDonViCongTac
{
    public class CreateDonViCongTacCommand : IRequest<string>, ICommand
    {
        public CreateDonViCongTacCommand(string name)
        {
            Name = name;
        }


        public string Name { get; set; }
    }
}
