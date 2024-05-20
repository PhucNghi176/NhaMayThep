using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Delete
{
    public class DeleteChiTietNgayNghiPhepCommand : IRequest<ChiTietNgayNghiPhepDto>, ICommand
    {
        public string Id { get; set; }

        public DeleteChiTietNgayNghiPhepCommand(string id)
        {
            Id = id;
        }
    }
}
