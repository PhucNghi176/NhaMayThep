using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHopDong.CreateNewLoaiHopDong
{
    public class CreateNewLoaiHopDongCommand : IRequest<string>, ICommand
    {
        public CreateNewLoaiHopDongCommand(string tenHopDong)
        {
            TenHopDong = tenHopDong;
        }
        public string TenHopDong {  get; set; }
    }
}
