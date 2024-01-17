using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.KhaiBaoTangLuong;
using NhaMayThep.Application.KhenThuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat
{
    public class KyLuatDto : IMapFrom<KyLuatEntity>
    {
        public KyLuatDto() { }

        public static KyLuatDto Create(string Id, string MaSoNhanVien, string HinhThucKyLuat, string LoaiKyLuat, string TenDotKyLuat, DateTime NgayKyLuat, double TongPhat, string DonViApDung)
        {
            return new KyLuatDto
            {
                Id = Id,
                MaSoNhanVien = MaSoNhanVien,
                HinhThucKyLuat = HinhThucKyLuat,
                LoaiKyLuat = LoaiKyLuat,
                TenDotKyLuat = TenDotKyLuat,
                NgayKyLuat = NgayKyLuat,
                TongPhat = TongPhat,
                DonViApDung = DonViApDung
            };
        }
        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public string HinhThucKyLuat { get; set; }
        public string LoaiKyLuat { get; set; }
        public string TenDotKyLuat { get; set; }
        public DateTime NgayKyLuat { get; set; }
        public double TongPhat { get; set; }
        public string DonViApDung { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<KyLuatEntity, KyLuatDto>();
        }
    }
}
