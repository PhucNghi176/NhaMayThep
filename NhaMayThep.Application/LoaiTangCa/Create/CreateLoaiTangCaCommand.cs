using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiTangCa.Create
{
    public class CreateLoaiTangCaCommand : IRequest<string>, ICommand
    {

        public string Name { get; set; }

        public CreateLoaiTangCaCommand()
        {

        }

        public CreateLoaiTangCaCommand(string name)
        {
            Name = name;
        }
    }
}