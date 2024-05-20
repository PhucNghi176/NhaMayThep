using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTru.DeleteThongTinGiamTru
{
    public class DeleteThongTinGiamTruCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public DeleteThongTinGiamTruCommand() { }
        public DeleteThongTinGiamTruCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
