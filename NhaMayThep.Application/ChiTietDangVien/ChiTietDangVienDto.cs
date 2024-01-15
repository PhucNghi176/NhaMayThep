using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.ThongTinDangVien;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietDangVien
{
    public class ChiTietDangVienDto : IMapFrom<ThongTinDangVienEntity>
    {
        public ChiTietDangVienDto()
        {
        }

        public string ID { get; set; }
        public string DangVienID { get; set; } //ThongTinDangVien
        public int DonViCongTacID { get; set; } 
        public string ChucVuDang { get; set; }
        public string TrinhDoChinhTri { get; set; }

        public string? NguoiTaoID { get; set; }
        public DateTime? NgayTao { get; set; }

        public string? NguoiCapNhatID { get; set; }
        public DateTime? NgayCapNhatCuoi { get; set; }

        public string? NguoiXoaID { get; set; }
        public DateTime? NgayXoa { get; set; }
        public static ChiTietDangVienDto Create(string id, string dangVienId, int donViCongTacId, string chucVuDang, string trinhDoChinhTri, string nguoiTaoId, DateTime ngayTao, string nguoiCapNhapId, DateTime ngayCapNhatCuoi, string nguoiXoaId, DateTime ngayXoa)
        {
            return new ChiTietDangVienDto
            {
                ID = id,
                DangVienID = dangVienId,
                DonViCongTacID = donViCongTacId,
                ChucVuDang = chucVuDang,
                TrinhDoChinhTri = trinhDoChinhTri,
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
            profile.CreateMap<ChiTietDangVienEntity, ChiTietDangVienDto>();
        }
    }
}
