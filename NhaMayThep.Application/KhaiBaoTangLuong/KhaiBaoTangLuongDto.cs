using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong
{
    public class KhaiBaoTangLuongDto : IMapFrom<KhaiBaoTangLuongEntity>
    {
        public static KhaiBaoTangLuongDto Create(string Id, Guid MaSoNhanVien, double PhanTramTang, DateTime NgayApDung, string LyDo)
        {
            return new KhaiBaoTangLuongDto
            {
                Id = Id,
                MaSoNhanVien = MaSoNhanVien,
                PhanTramTang = PhanTramTang,
                NgayApDung = NgayApDung,
                LyDo = LyDo
            };
        }
        public string Id { get; set; }
        public Guid MaSoNhanVien { get; set; }
        public double PhanTramTang { get; set; }
        public DateTime NgayApDung { get; set; }
        public string LyDo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<KhaiBaoTangLuongEntity, KhaiBaoTangLuongDto>();
        }
    }
}
