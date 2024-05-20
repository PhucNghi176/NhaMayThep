using MediatR;

namespace NhaMayThep.Application.ChiTietBaoHiem.DeleteChiTietBaoHiem
{
    public class DeleteChiTietBaoHiemCommand : IRequest<string>, IRequest
    {
        public DeleteChiTietBaoHiemCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
