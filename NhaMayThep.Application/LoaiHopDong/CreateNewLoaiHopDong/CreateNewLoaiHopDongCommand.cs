using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiHopDong.CreateNewLoaiHopDong
{
    public class CreateNewLoaiHopDongCommand : IRequest<string>, ICommand
    {
        public CreateNewLoaiHopDongCommand(string tenHopDong)
        {
            TenHopDong = tenHopDong;
        }
        public string TenHopDong { get; set; }
    }
}
