using MediatR;

namespace NhaMayThep.Application.ChiTietBaoHiem.RestoreChiTietBaoHiem
{
    public class RestoreChiTietBaoHiemCommand : IRequest<string>, IRequest
    {
        public RestoreChiTietBaoHiemCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
