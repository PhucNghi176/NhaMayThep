using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh
{
    public class ThongTinGiamTruGiaCanhDto : IMapFrom<ThongTinGiamTruGiaCanhEntity>
    {
        public string Id { get; set; } = null!;
        public string? NhanVienID { get; set; }
        public string NhanVien { get; set; } = null!;
        public int? MaGiamTruID { get; set; }
        public string ThongTinGiamTru { get; set; } = null!;
        public string DiaChiLienLac { get; set; } = null!;
        public string QuanHeVoiNhanVien { get; set; } = null!;
        public string CanCuocCongDan { get; set; } = null!;
        public DateTime NgayXacNhanPhuThuoc { get; set; }

        public static ThongTinGiamTruGiaCanhDto CreateThongTinGiamTruGiaCanh(
            string id,
            string nhanvien,
            string thongtingiamtru,
            string diachi,
            string quanhevoinhanvien,
            string cancuoccongdan,
            string nhanvienid,
            int magiamtruid,
            DateTime ngayxacnhan)
        {
            return new ThongTinGiamTruGiaCanhDto
            {
                Id = id,
                NhanVien = nhanvien,
                ThongTinGiamTru = thongtingiamtru,
                DiaChiLienLac = diachi,
                QuanHeVoiNhanVien = quanhevoinhanvien,
                CanCuocCongDan = cancuoccongdan,
                NgayXacNhanPhuThuoc = ngayxacnhan,
                NhanVienID = nhanvienid,
                MaGiamTruID= magiamtruid
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinGiamTruGiaCanhEntity, ThongTinGiamTruGiaCanhDto>();
        }
    }
}
