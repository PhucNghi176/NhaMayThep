using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan
{
    public class UpdateThongTinCongDoanCommand: IRequest<ThongTinCongDoanDto>, ICommand
    {
        public UpdateThongTinCongDoanCommand(
            string id, 
            string nhanvienid,
            bool thukycongdoan, 
            DateTime? ngaygianhap)
        {
            Id= id;
            NhanVienId = nhanvienid;
            ThuKyCongDoan = thukycongdoan;
            NgayGiaNhap= ngaygianhap;
        }
        public void NguoiCapNhat(string value)
        {
            NguoiCapNhatId = value;
        }
        public string? NguoiCapNhatid
        {
            get { return NguoiCapNhatId; }
        }
        private string? NguoiCapNhatId;
        public string Id { get; set; }
        public string NhanVienId { get; set; }
        public bool ThuKyCongDoan { get; set; }
        public DateTime? NgayGiaNhap { get; set; }
    }
}
