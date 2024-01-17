using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiHopDong.UpdateLoaiHopDong
{
    public class UpdateLoaiHopDongCommand : IRequest<LoaiHopDongDto>, ICommand
    {
        public UpdateLoaiHopDongCommand(int id, string tenHopDong)
        {
            Id = id;
            TenHopDong = tenHopDong;
        }

        public int Id { get; set; }
        public string TenHopDong { get; set; }
    }
}
