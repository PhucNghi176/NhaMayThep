using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.CreateKhenThuong
{
    public class CreateKhenThuongCommand : IRequest<string>, ICommand
    {
        public string MaSoNhanVien { get; set; }
        public int ChinhSachNhanSuID { get; set; }
        public string TenDotKhenThuong { get; set; }
        public decimal TongThuong { get; set; }
        public CreateKhenThuongCommand() { }
        public CreateKhenThuongCommand(string maSoNhanVien, int chinhSachNhanSuID, string tenDotKhenThuong, decimal tongThuong)
        {
            MaSoNhanVien = maSoNhanVien;
            ChinhSachNhanSuID = chinhSachNhanSuID;
            TenDotKhenThuong = tenDotKhenThuong;
            TongThuong = tongThuong;
        }
    }
}
