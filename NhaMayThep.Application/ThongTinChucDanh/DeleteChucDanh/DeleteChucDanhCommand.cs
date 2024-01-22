using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucDanh.DeleteChucDanh
{
    public class DeleteChucDanhCommand : IRequest<string>, ICommand
    {
        public DeleteChucDanhCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
