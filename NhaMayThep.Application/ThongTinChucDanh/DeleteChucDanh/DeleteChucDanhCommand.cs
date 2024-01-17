using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucDanh.DeleteChucDanh
{
    public class DeleteChucDanhCommand :IRequest<string>, ICommand
    {
        public DeleteChucDanhCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
