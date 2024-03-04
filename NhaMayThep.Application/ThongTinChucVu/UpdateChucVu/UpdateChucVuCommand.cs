using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucVu.UpdateChucVu
{
    public class UpdateChucVuCommand : IRequest<string>, ICommand
    {
        public UpdateChucVuCommand() { }
        public UpdateChucVuCommand(int id, string tenChucVu)
        {
            Id = id;
            Name = tenChucVu;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
