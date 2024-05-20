using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.ThueTNCN
{
    public class ThueTNCNDto : IMapFrom<ThueTNCNEntity>
    {
        public ThueTNCNDto()
        {

        }

        public string MaSoNhanVien { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal TongThuNhap { get; set; }
        public decimal ThuNhapChiuThue { get; set; }
        public decimal ThuNhapTinhThue { get; set; }
        public string GiamTruNhanVienID { get; set; }
        public decimal ThueTNCNPhaiNop { get; set; }

        public static ThueTNCNDto Create(string maSoNhanVien, decimal luongCoBan, decimal tongThuNhap, decimal thuNhapChiuThue, decimal thuNhapTinhThue, string giamTruNhanVienID, decimal thueTNCNPhaiNop)
        {
            return new ThueTNCNDto
            {
                MaSoNhanVien = maSoNhanVien,
                LuongCoBan = luongCoBan,
                TongThuNhap = tongThuNhap,
                ThuNhapChiuThue = thuNhapChiuThue,
                ThuNhapTinhThue = thueTNCNPhaiNop,
                GiamTruNhanVienID = giamTruNhanVienID,
                ThueTNCNPhaiNop = thueTNCNPhaiNop
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThueTNCNEntity, ThueTNCNDto>();
        }

    }
}
