using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Delete
{
    public class DeleteThongTinLuongNhanVienCommand : IRequest<ThongTinLuongNhanVienDto>, ICommand
    {
        public DeleteThongTinLuongNhanVienCommand(Guid Id)
        {
            this.Id = Id.ToString();
        }
        public string Id { get; set; }
    }
}
