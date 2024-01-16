using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.KhaiBaoTangLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu
{
    public class ChinhSachNhanSuDto : IMapFrom<ChinhSachNhanSuEntity>
    {
        public ChinhSachNhanSuDto() { }
        public static ChinhSachNhanSuDto Create(int Id, string LoaiHinhThuc, string MucDo, DateTime NgayHieuLuc, string NoiDung)
        {
            return new ChinhSachNhanSuDto
            {
                Id = Id,
                LoaiHinhThuc = LoaiHinhThuc,
                MucDo = MucDo,
                NgayHieuLuc = NgayHieuLuc,
                NoiDung = NoiDung
            };
        }
        public int Id { get; set; }
        public string LoaiHinhThuc { get; set; }
        public string MucDo { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public string? NoiDung { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChinhSachNhanSuEntity, ChinhSachNhanSuDto>();
        }
    }
}
