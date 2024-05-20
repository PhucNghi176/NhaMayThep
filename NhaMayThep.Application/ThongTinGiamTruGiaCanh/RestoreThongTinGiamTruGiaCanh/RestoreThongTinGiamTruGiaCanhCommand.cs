using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.RestoreThongTinGiamTruGiaCanh
{
    public class RestoreThongTinGiamTruGiaCanhCommand : IRequest<string>, ICommand
    {
        public RestoreThongTinGiamTruGiaCanhCommand(string id)
        {
            this.Id = id;
        }
        public string Id { get; set; }
    }
}
