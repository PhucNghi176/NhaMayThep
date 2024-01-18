using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiCongTac.Create
{
    public class CreateLoaiCongTacCommand : IRequest<string>, ICommand
    {

        public CreateLoaiCongTacCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

    }
}
