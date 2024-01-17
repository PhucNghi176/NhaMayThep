using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiCongTac.Create
{
    public class CreateLoaiCongTacCommand : IRequest, ICommand
    {

        public CreateLoaiCongTacCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

    }
}
