using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiNghiPhep.Create
{
    public class CreateLoaiNghiPhepCommand : IRequest<string>, ICommand
    {

        public string Name { get; set; }

        public CreateLoaiNghiPhepCommand()
        {

        }

        public CreateLoaiNghiPhepCommand(string name)
        {

            Name = name;
        }
    }
}
