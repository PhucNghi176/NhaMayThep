using MediatR;

namespace NhaMayThep.Application.LoaiHoaDon.Create
{
    public class CreateLoaiHoaDonCommand : IRequest<LoaiHoaDonDto>
    {
        public CreateLoaiHoaDonCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
