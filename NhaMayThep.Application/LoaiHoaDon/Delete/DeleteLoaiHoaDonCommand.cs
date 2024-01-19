using MediatR;

namespace NhaMayThep.Application.LoaiHoaDon.Delete
{
    public class DeleteLoaiHoaDonCommand : IRequest<string>
    {
        public DeleteLoaiHoaDonCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
