using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LichSuNghiPhep.Delete
{
    public class DeleteLichSuNghiPhepCommand : IRequest<LichSuNghiPhepDto>, ICommand
    {
        public string Id { get; set; }


        public DeleteLichSuNghiPhepCommand(string id)
        {
            Id = id;
        }
    }
}
