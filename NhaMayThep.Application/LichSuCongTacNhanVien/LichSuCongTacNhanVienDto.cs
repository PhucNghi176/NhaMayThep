using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;


namespace NhaMayThep.Application.LichSuCongTacNhanVien
{
    public class LichSuCongTacNhanVienDto : IMapFrom<LichSuCongTacNhanVienEntity>
    {

        public LichSuCongTacNhanVienDto() { }

        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public string HoVaTen { get; set; }
        public int LoaiCongTacID { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string NoiCongTac { get; set; }
        public string LyDo { get; set; }

        public static LichSuCongTacNhanVienDto Create(string id, string maSoNhanVien, int loaiCongTac, DateTime ngaybatdau,
            DateTime? ngayKetThuc, string noiCongTac, string Lydo)
        {
            return new LichSuCongTacNhanVienDto()
            {
                Id = id,
                NgayBatDau = ngaybatdau,
                NgayKetThuc = ngayKetThuc,
                MaSoNhanVien = maSoNhanVien,
                LoaiCongTacID = loaiCongTac,
                NoiCongTac = noiCongTac,
                LyDo = Lydo
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LichSuCongTacNhanVienEntity, LichSuCongTacNhanVienDto>();
        }
    }
}
