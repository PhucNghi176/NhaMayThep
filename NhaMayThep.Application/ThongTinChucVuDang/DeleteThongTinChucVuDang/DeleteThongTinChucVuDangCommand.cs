using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVuDang.DeleteThongTinChucVuDang
{
    public class DeleteThongTinChucVuDangCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public DeleteThongTinChucVuDangCommand(int id)
        {
            Id = id;
        }
    }
}
