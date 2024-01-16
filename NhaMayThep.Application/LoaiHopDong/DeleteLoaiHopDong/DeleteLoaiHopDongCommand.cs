using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHopDong.DeleteLoaiHopDong
{
    public class DeleteLoaiHopDongCommand :IRequest<string>, ICommand
    {
        public DeleteLoaiHopDongCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
