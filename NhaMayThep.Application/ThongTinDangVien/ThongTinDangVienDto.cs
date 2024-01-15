using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.DonViCongTac;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien
{
    public class ThongTinDangVienDto : IMapFrom<ThongTinDangVienEntity>
    {
        public ThongTinDangVienDto()
        {
        }

        public string ID { get; set; }
        public string NhanVienID { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public string CapDangVien { get; set; }

        public string? NguoiTaoID { get; set; }
        public DateTime? NgayTao { get; set; }

        public string? NguoiCapNhatID { get; set; }
        public DateTime? NgayCapNhatCuoi { get; set; }

        public string? NguoiXoaID { get; set; }
        public DateTime? NgayXoa { get; set; }
        public static ThongTinDangVienDto Create(string id, string nhanVienId, DateTime ngayVaoDang, string capDangVien, string nguoiTaoId, DateTime ngayTao, string nguoiCapNhapId, DateTime ngayCapNhatCuoi, string nguoiXoaId, DateTime ngayXoa)
        {
            return new ThongTinDangVienDto
            {
               ID = id,
               NhanVienID = nhanVienId,
               NgayVaoDang = ngayVaoDang,
               CapDangVien = capDangVien,
               NguoiTaoID = nguoiTaoId,
               NgayTao = ngayTao,
               NguoiCapNhatID = nguoiCapNhapId,
               NgayCapNhatCuoi = ngayCapNhatCuoi,
               NguoiXoaID = nguoiXoaId,
               NgayXoa = ngayXoa
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinDangVienEntity, ThongTinDangVienDto>();
        }
    }
}
