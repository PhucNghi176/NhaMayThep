using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.DeleteThongTinGiamTruGiaCanh
{
    public class DeleteThongTinGiamTruGiaCanhCommand : IRequest<string>, ICommand
    {
        public DeleteThongTinGiamTruGiaCanhCommand(string id)
        {
            this.Id = id;
        }
        public string Id { get; set; }
    }
}
