using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CapBacLuong.CreateCapBacLuong
{
    public class CreateCapBacLuongCommand : IRequest<string>, ICommand
    {
        public string TenCapBac { get; set; }
        public float HeSoLuong { get; set; }
        public CreateCapBacLuongCommand(string tenCapBac, float heSoLuong)
        {
            TenCapBac = tenCapBac;
            HeSoLuong = heSoLuong;
        }
    }
}
