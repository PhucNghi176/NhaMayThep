using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TangCa.Update
{
    public class UpdateTangCaCommand : IRequest<string>, ICommand
    {
        public string MaSoNhanVien { get; set; }
        public double SoGioLamThem { get; set; }
        public int SoSanPhamLamThem { get; set; }
        public decimal LuongSanPham { get; set; }
        public decimal LuongCongNhat { get; set; }
        public int LoaiTangCaID { get; set; }
        public string ID { get; set; }
        public UpdateTangCaCommand(string Id, string maSoNhanVien, double soGioLamThem, int soSanPhamLamThem, decimal luongSanPham, decimal luongCongNhat, int loaiTangCaId)
        {
            ID = Id;
            MaSoNhanVien = maSoNhanVien;
            SoGioLamThem = soGioLamThem;
            SoSanPhamLamThem = soSanPhamLamThem;
            LuongCongNhat = luongCongNhat;
            LuongSanPham = luongSanPham;
            LoaiTangCaID = loaiTangCaId;
        }
        public UpdateTangCaCommand() { }
    }
}
