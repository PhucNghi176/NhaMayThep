using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;

namespace NhaMayThep.Application.ThongTinDaoTao
{
    public class ThongTinDaoTaoDto : IMapFrom<ThongTinDaoTaoEntity>
    {
        public ThongTinDaoTaoDto() { }

        public string NhanVienID { get; set; }
        public int MaTrinhDoHocVanID { get; set; }
        public string TenTruong { get; set; }
        public string ChuyenNganh { get; set; }
        public DateTime NamTotNghiep { get; set; }
        public int TrinhDoVanHoa { get; set; }


        public static ThongTinDaoTaoDto CreateThongTinDaoTao(string nhanVienId, int maTrinhDoHocVanId, string tenTruong, string chuyenNganh, DateTime namTotNghiep, int trinhDoVanHoa)
        {
            return new ThongTinDaoTaoDto()
            {
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
