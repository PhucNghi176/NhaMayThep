using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CanCuocCongDan
{
    public class CanCuocCongDanDto : IMapFrom<CanCuocCongDanEntity>
    {
        public required string ID { get; set; }
        public required string CanCuocCongDan { get; set; }
        public required string HoVaTen { get; set; }
        public required DateTime NgaySinh { get; set; }
        public required bool GioiTinh { get; set; }
        public required string QuocTich { get; set; }
        public required string QueQuan { get; set; }
        public required string DiaChiThuongTru { get; set; }
        public required DateTime NgayCap { get; set; }
        public required string NoiCap { get; set; }
        public required string DanToc { get; set; }
        public required string TonGiao { get; set; }
        public static CanCuocCongDanDto Create(string id, string canCuocCongDan, string hoVaTen, DateTime ngaySinh, bool gioiTinh, string quocTich, string queQuan, string diaChiThuongTru, DateTime ngayCap, string noiCap, string danToc, string tonGiao)
        {
            return new CanCuocCongDanDto
            {
                ID = id,
                CanCuocCongDan = canCuocCongDan,
                HoVaTen = hoVaTen,
                NgaySinh = ngaySinh,
                GioiTinh = gioiTinh,
                QuocTich = quocTich,
                QueQuan = queQuan,
                DiaChiThuongTru = diaChiThuongTru,
                NgayCap = ngayCap,
                NoiCap = noiCap,
                DanToc = danToc,
                TonGiao = tonGiao
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CanCuocCongDanEntity, CanCuocCongDanDto>();
        }
    }
}
