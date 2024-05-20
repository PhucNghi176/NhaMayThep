using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiTangCa.Delete
{
    public class DeleteLoaiTangCaCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }


        public DeleteLoaiTangCaCommand(int id)
        {
            Id = id;
        }
    }
}
