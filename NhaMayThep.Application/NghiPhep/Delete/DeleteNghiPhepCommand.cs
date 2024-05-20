using MediatR;
using NhaMayThep.Application.Common.Interfaces;


namespace NhaMayThep.Application.NghiPhep.Delete
{
    public class DeleteNghiPhepCommand : IRequest<string>, ICommand
    {
        public DeleteNghiPhepCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
