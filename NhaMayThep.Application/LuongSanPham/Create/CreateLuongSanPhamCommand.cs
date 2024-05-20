using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongSanPham.Create
{
    public class CreateLuongSanPhamCommand : IRequest<string>, ICommand
    {
        public CreateLuongSanPhamCommand(string maSoNhanVien, int soSanPhamLam, string mucSanPhamId, decimal tongLuong, DateTime ngayKhaiBao)
        {

            MaSoNhanVien = maSoNhanVien;
            SoSanPhamLam = soSanPhamLam;
            MucSanPhamID = mucSanPhamId;
            TongLuong = tongLuong;
            NgayKhaiBao = ngayKhaiBao;
        }


        public string MaSoNhanVien { get; set; }
        public int SoSanPhamLam { get; set; }
        public string MucSanPhamID { get; set; }
        public decimal TongLuong { get; set; }
        public DateTime NgayKhaiBao { get; set; }

    }
}