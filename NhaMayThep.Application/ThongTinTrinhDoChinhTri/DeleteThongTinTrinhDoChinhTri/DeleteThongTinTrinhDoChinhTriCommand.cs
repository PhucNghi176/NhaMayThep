using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.DeleteThongTinTrinhDoChinhTri
{
    public class DeleteThongTinTrinhDoChinhTriCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public DeleteThongTinTrinhDoChinhTriCommand(int id)
        {
            Id = id;
        }
    }
}
