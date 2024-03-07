using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCapDangVien.DeleteThongTinCapDangVien
{
    public class DeleteThongTinCapDangVienCommand : IRequest<string>, ICommand
    {
        public int Id { get; set; }
        public DeleteThongTinCapDangVienCommand(int id)
        {
            Id = id;
        }
    }
}
