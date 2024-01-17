using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.CreateThongTinCongDoan
{
    public class CreateThongTinCongDoanCommand : IRequest<string>, ICommand
    {
        public CreateThongTinCongDoanCommand(
            string nhanVienID, 
            bool thuKyCongDoan,
            DateTime ngaygianhap)
        {
            NhanVienID = nhanVienID;
            ThuKyCongDoan = thuKyCongDoan;
            NgayGiaNhap = ngaygianhap;
        };
        public string NhanVienID { get;set; }
        public bool ThuKyCongDoan { get; set; }
        public DateTime NgayGiaNhap { get; set; }
    }
}
