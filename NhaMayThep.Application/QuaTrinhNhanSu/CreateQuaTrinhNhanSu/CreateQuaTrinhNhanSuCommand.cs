using MediatR;
using NhaMayThep.Application.Common.Interfaces;


namespace NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu
{
    public class CreateQuaTrinhNhanSuCommand : IRequest<bool>, ICommand
    {
        public CreateQuaTrinhNhanSuCommand(string maSoNhanVien
            , int loaiQuaTrinhID
            , DateTime ngayBatDau
            , DateTime? ngayKetThuc
            , int phongBanID
            , int chucVuId
            , int chucDanhID
            , string? ghiChu)
        {
            MaSoNhanVien = maSoNhanVien;
            LoaiQuaTrinhID = loaiQuaTrinhID;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            PhongBanID = phongBanID;
            ChucDanhID = chucDanhID;
            ChucVuID = chucVuId;
            GhiChu = ghiChu;
        }
        public string MaSoNhanVien { get; set; }
        public int LoaiQuaTrinhID { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int PhongBanID { get; set; }
        public int ChucVuID { get; set; }
        public int ChucDanhID { get; set; }
        public string? GhiChu { get; set; }
    }
}
