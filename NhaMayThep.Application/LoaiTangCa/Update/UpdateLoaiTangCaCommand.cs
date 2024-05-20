using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiTangCa.Update
{
    public class UpdateLoaiTangCaCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public UpdateLoaiTangCaCommand()
        {

        }
        public UpdateLoaiTangCaCommand(int id, string name, int sgnp)
        {

            Id = id;
            Name = name;
        }

    }
}
