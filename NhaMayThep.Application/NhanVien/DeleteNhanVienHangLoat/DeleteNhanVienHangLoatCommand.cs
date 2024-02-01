using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.DeleteNhanVienHangLoat
{
    public class DeleteNhanVienHangLoatCommand : IRequest<string>, ICommand
    {
        public List<string> Ids { get; set; }

        public DeleteNhanVienHangLoatCommand(List<string> ids)
        {
            Ids = ids;
        }
    }
}
