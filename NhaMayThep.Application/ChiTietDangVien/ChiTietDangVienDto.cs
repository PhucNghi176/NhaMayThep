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

        public static ChiTietDangVienDto Create(string id, string dangVienId, int donViCongTacId, string chucVuDang, string trinhDoChinhTri)
        {
            return new ChiTietDangVienDto
            {
                ID = id,
                DangVienID = dangVienId,
                DonViCongTacID = donViCongTacId,
                ChucVuDang = chucVuDang,
                TrinhDoChinhTri = trinhDoChinhTri,
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChiTietDangVienEntity, ChiTietDangVienDto>();
        }
    }
}
