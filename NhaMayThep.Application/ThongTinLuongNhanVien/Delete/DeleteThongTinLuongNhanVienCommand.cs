using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Delete
{
    public class DeleteThongTinLuongNhanVienCommand : IRequest<string>, ICommand
    {
        public DeleteThongTinLuongNhanVienCommand(string Id)
        {
            this.Id = Id;
        }
        public string Id { get; set; }
    }
}
