using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.QuaTrinhNhanSu.UpdateQuaTrinhNhanSu
{
    public class UpdateQuaTrinhNhanSuCommand : IRequest<bool>, ICommand
    {
        public UpdateQuaTrinhNhanSuCommand(string id
            , int loaiQuaTrinhID
            , DateTime? ngayKetThuc
            , int phongBanID
            , int chucVuID
            , int chucDanhID
            , string? ghiChu)
        {
            ID = id;
            LoaiQuaTrinhID = loaiQuaTrinhID;
            NgayKetThuc = ngayKetThuc;
            PhongBanID = phongBanID;
            ChucVuID = chucVuID;
            ChucDanhID = chucDanhID;
            GhiChu = ghiChu;
        }
        public string ID { get; set; }
        public int LoaiQuaTrinhID { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int PhongBanID { get; set; }
        public int ChucVuID { get; set; }
        public int ChucDanhID { get; set; }
        public string? GhiChu { get; set; }
    }
}
