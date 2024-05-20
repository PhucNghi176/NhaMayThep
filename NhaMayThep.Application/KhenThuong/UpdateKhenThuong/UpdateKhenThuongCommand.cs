using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KhenThuong.UpdateKhenThuong
{
    public class UpdateKhenThuongCommand : IRequest<string>, ICommand
    {
        public string MaSoNhanVien { get; set; }
        public string ID { get; set; }
        public int ChinhSachNhanSuID { get; set; }
        public string TenDotKhenThuong { get; set; }
        public decimal TongThuong { get; set; }
        public UpdateKhenThuongCommand(string Id, string maSoNhanVien, int chinhSachNhanSuID, string tenDotKhenThuong, decimal tongThuong)
        {
            ID = Id;
            MaSoNhanVien = maSoNhanVien;
            ChinhSachNhanSuID = chinhSachNhanSuID;
            TenDotKhenThuong = tenDotKhenThuong;
            TongThuong = tongThuong;
        }
        public UpdateKhenThuongCommand() { }
    }
}
