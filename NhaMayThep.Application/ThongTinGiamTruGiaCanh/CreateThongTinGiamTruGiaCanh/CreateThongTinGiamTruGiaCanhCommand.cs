using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.CreateThongTinGiamTruGiaCanh
{
    public class CreateThongTinGiamTruGiaCanhCommand: IRequest<int>, ICommand
    {
        public CreateThongTinGiamTruGiaCanhCommand(
            string nhanvienid,
            int magiamtruid,
            string diachilienlac,
            string quanhevoinhanvien,
            string cancuoccongdan,
            DateTime ngayxacnhanphuthuoc)
        {
            NhanVienID = nhanvienid;
            MaGiamTruID = magiamtruid;
            DiaChiLienLac = diachilienlac;
            QuanHeVoiNhanVien = quanhevoinhanvien;
            CanCuocCongDan = cancuoccongdan;
            NgayXacNhanPhuThuoc = ngayxacnhanphuthuoc;
        }
        public void NguoiTao(string value)
        {
            nguoiTaoId = value;
        }
        public string? NguoiTaoId
        {
            get { return nguoiTaoId; }
        }
        private string? nguoiTaoId;
        public string NhanVienID { get;set; }
        public int MaGiamTruID { get; set; }
        public string DiaChiLienLac { get; set; }
        public string QuanHeVoiNhanVien { get; set; }
        public string CanCuocCongDan { get; set; }
        public DateTime NgayXacNhanPhuThuoc { get; set; }
    }
}
