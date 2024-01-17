using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh
{
    public class ThongTinGiamTruGiaCanhDto : IMapFrom<ThongTinGiamTruGiaCanhEntity>
    {
        public string Id { get; set; } = null!;
        public string NhanVienID { get; set; } = null!;
        public string MaGiamTruID { get; set; } = null!;
        public string DiaChiLienLac { get; set; } = null!;
        public string QuanHeVoiNhanVien { get; set; } = null!;
        public string CanCuocCongDan { get; set; } = null!;
        public DateTime NgayXacNhanPhuThuoc { get; set; }

        public static ThongTinGiamTruGiaCanhDto CreateThongTinGiamTruGiaCanh(
            string id,
            string nhanvienid,
            string magiamtru,
            string diachi,
            string quanhevoinhanvien,
            string cancuoccongdan,
            DateTime ngayxacnhan)
        {
            return new ThongTinGiamTruGiaCanhDto
            {
                Id = id,
                NhanVienID = nhanvienid,
                MaGiamTruID = magiamtru,
                DiaChiLienLac = diachi,
                QuanHeVoiNhanVien = quanhevoinhanvien,
                CanCuocCongDan = cancuoccongdan,
                NgayXacNhanPhuThuoc = ngayxacnhan
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinGiamTruGiaCanhEntity, ThongTinGiamTruGiaCanhDto>();
        }
    }
}
