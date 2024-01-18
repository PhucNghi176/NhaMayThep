using MediatR;

namespace NhaMayThep.Application.LoaiHoaDon.Update
{
    public class UpdateLoaiHoaDonCommand : IRequest<string>
    {
        public UpdateLoaiHoaDonCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
