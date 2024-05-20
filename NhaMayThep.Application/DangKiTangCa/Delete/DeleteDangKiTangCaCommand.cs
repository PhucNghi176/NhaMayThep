using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.DangKiTangCa.Delete
{
    public class DeleteDangKiTangCaCommand : IRequest<string>, ICommand

    {
        public string Id { get; set; }


        public DeleteDangKiTangCaCommand(string id)
        {
            Id = id;
        }
    }
}
