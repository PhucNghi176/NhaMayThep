using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiNghiPhep.Delete;
public class DeleteLoaiNghiPhepCommand : IRequest<string>, ICommand
{
    public int Id { get; set; }
    public string NguoiXoaID { get; set; }

    public DeleteLoaiNghiPhepCommand(int id)
    {
        Id = id;
    }
}
