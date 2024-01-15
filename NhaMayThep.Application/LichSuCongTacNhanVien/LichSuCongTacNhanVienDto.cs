using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien
{
    public class LichSuCongTacNhanVienDto : IMapFrom<LichSuCongTacNhanVienEntity>
    {

        public LichSuCongTacNhanVienDto() { }
        public string MaSoNhanVien { get; set; }
        public LoaiCongTacEntity  LoaiCongTac { get; set; }
        public  DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public  string NoiCongTac { get; set; }
        public  string LyDo { get; set; }

        public static LichSuCongTacNhanVienDto Create(string maSoNhanVien, LoaiCongTacEntity loaiCongTac, DateTime ngaybatdau, 
            DateTime ngayKetThuc, string noiCongTac,string Lydo)
        {
            return new LichSuCongTacNhanVienDto()
            {
                NgayBatDau = ngaybatdau,
                NgayKetThuc = ngayKetThuc,
                MaSoNhanVien = maSoNhanVien,
                LoaiCongTac = loaiCongTac,
                NoiCongTac = noiCongTac,
                LyDo = Lydo
            };
        }

        public void Mapping(Profile profile)
        {
          profile.CreateMap<LichSuCongTacNhanVienEntity,LichSuCongTacNhanVienDto>();
        }
    }
}
