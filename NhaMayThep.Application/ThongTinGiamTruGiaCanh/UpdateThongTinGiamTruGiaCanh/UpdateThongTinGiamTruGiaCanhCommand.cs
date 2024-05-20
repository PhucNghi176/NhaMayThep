using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.UpdateThongTinGiamTruGiaCanh
{
    public class UpdateThongTinGiamTruGiaCanhCommand : IRequest<string>, ICommand
    {
        public UpdateThongTinGiamTruGiaCanhCommand(
           string id,
           int magiamtruid,
           string diachilienlac,
           string quanhevoinhanvien,
           string cancuoccongdan,
           DateTime ngayxacnhanphuthuoc)
        {
            Id = id;
            MaGiamTruID = magiamtruid;
            DiaChiLienLac = diachilienlac;
            QuanHeVoiNhanVien = quanhevoinhanvien;
            CanCuocCongDan = cancuoccongdan;
            NgayXacNhanPhuThuoc = ngayxacnhanphuthuoc;
        }
        public string Id { get; set; }
        public int MaGiamTruID { get; set; } = 1;
        public string? DiaChiLienLac { get; set; }
        public string? QuanHeVoiNhanVien { get; set; }
        public string CanCuocCongDan { get; set; }
        public DateTime NgayXacNhanPhuThuoc { get; set; } = DateTime.Now;
    }
}
