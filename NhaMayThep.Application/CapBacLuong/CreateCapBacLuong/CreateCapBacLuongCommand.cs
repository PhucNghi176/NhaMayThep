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
        public string TrinhDo {  get; set; }
        public CreateCapBacLuongCommand(string tenCapBac, float heSoLuong, string trinhDo)
        {
            TenCapBac = tenCapBac;
            HeSoLuong = heSoLuong;
            TrinhDo = trinhDo;
        }
    }
}
