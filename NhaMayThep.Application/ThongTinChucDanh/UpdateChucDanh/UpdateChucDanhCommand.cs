using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucDanh.UpdateChucDanh
{
    public class UpdateChucDanhCommand : IRequest<string>, ICommand
    {
        public UpdateChucDanhCommand() { }
        public UpdateChucDanhCommand(int id, string tenChucDanh)
        {
            Id = id;
            Name = tenChucDanh;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
