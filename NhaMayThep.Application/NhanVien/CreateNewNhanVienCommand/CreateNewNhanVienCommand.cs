using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.CreateNewNhanVienCommand
{
    public class CreateNewNhanVienCommand : IRequest<string>, ICommand
    {
        public CreateNewNhanVienCommand(NhanVienEntity NhanVien)
        {
            NhanVien
        }

        public NhanVienEntity NhanVien { get; set;}
    }
}
