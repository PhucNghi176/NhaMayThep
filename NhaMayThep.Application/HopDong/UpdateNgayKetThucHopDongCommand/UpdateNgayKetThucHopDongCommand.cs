using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HopDong.UpdateNgayKetThucHopDongCommand
{
    public class UpdateNgayKetThucHopDongCommand : IRequest<string>
    {
        public string Id { get; set; }

        public UpdateNgayKetThucHopDongCommand(string id) 
        { 
            Id = id;
        }

        public UpdateNgayKetThucHopDongCommand() { }
    }
}
