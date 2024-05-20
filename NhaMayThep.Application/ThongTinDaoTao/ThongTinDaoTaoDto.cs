using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.ThongTinDaoTao
{
    public class ThongTinDaoTaoDto : IMapFrom<ThongTinDaoTaoEntity>
    {
        public ThongTinDaoTaoDto() { }
        public string ID { get; set; }
        public string NhanVienID { get; set; }
        public int MaTrinhDoHocVanID { get; set; }
        public string TenTruong { get; set; }
        public string ChuyenNganh { get; set; }
        public DateTime NamTotNghiep { get; set; }
        public int TrinhDoVanHoa { get; set; }


        public static ThongTinDaoTaoDto CreateThongTinDaoTao(string Id, string nhanVienId, int maTrinhDoHocVanId, string tenTruong, string chuyenNganh, DateTime namTotNghiep, int trinhDoVanHoa)
        {
            return new ThongTinDaoTaoDto()
            {
                ID = Id,
                NhanVienID = nhanVienId,
                MaTrinhDoHocVanID = maTrinhDoHocVanId,
                TenTruong = tenTruong,
                ChuyenNganh = chuyenNganh,
                NamTotNghiep = namTotNghiep,
                TrinhDoVanHoa = trinhDoVanHoa
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinDaoTaoEntity, ThongTinDaoTaoDto>();
        }
    }
}
