using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiNghiPhep.Update
{
    public class UpdateLoaiNghiPhepCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public UpdateLoaiNghiPhepCommand()
        {

        }
        public UpdateLoaiNghiPhepCommand(int id, string name, int sgnp)
        {

            Id = id;
            Name = name;


        }

    }
}