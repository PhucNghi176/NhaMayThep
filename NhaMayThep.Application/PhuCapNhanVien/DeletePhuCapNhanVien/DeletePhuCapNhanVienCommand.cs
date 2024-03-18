using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhuCapNhanVien.DeletePhuCapNhanVien
{
    public class DeletePhuCapNhanVienCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public DeletePhuCapNhanVienCommand(int id)
        {
            Id = id;
        }
    }
}
