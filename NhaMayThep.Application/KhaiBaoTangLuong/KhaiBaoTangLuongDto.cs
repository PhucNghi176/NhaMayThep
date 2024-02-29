using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong
{
    public class KhaiBaoTangLuongDto : IMapFrom<KhaiBaoTangLuongEntity>
    {
        public KhaiBaoTangLuongDto()
        {
        }

        public string ID { get; set; }
        public required string MaSoNhanVien { get; set; }
        public float PhanTramTang { get; set; }
        public DateTime NgayApDung { get; set; }
        public string LyDo { get; set; }

        public static KhaiBaoTangLuongDto Create(string id, string maSoNhanVien, float phanTramTang, DateTime ngayApDung, string lyDo)
        {
            return new KhaiBaoTangLuongDto
            {
                ID = id,
                MaSoNhanVien = maSoNhanVien,
                PhanTramTang = phanTramTang,
                NgayApDung = ngayApDung,
                LyDo = lyDo,
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<KhaiBaoTangLuongEntity, KhaiBaoTangLuongDto>();
        }
    }
}