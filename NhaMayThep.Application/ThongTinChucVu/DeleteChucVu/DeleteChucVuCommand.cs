using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVu.DeleteChucVu
{
    public class DeleteChucVuCommand :IRequest<string>, ICommand
    {
        public DeleteChucVuCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
