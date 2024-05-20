using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongCongNhat.Update
{
    public class UpdateLuongCongNhatCommand : IRequest<string>, ICommand
    {
        public UpdateLuongCongNhatCommand(string id, string maSoNhanVien, double soGioLam, decimal luong1Gio, decimal tongLuong, DateTime ngayKhaiBao)
        {
            ID = id;
            MaSoNhanVien = maSoNhanVien;
            SoGioLam = soGioLam;
            Luong1Gio = luong1Gio;
            TongLuong = tongLuong;
            NgayKhaiBao = ngayKhaiBao;
        }
        public string ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public double SoGioLam { get; set; }

        public decimal Luong1Gio { get; set; }

        public decimal TongLuong { get; set; }
        public DateTime NgayKhaiBao { get; set; }
    }
}
