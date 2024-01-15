using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan
{
    public class UpdateThongTinCongDoanCommand: IRequest<bool>, ICommand
    {
        public UpdateThongTinCongDoanCommand(string id, bool thukycongdoan, DateTime? ngaygianhap)
        {
            Id= id;
            ThuKyCongDoan = thukycongdoan;
            NgayGiaNhap= ngaygianhap;
        }
        public string Id { get; set; }
        public bool ThuKyCongDoan { get; set; }
        public DateTime? NgayGiaNhap { get; set; }
    }
}
