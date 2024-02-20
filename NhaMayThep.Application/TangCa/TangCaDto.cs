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

namespace NhaMayThep.Application.TangCa
{
    public class TangCaDto : IMapFrom<TangCaEntity>
    {
        public TangCaDto()
        {

        }
        public string ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public double SoGioLamThem { get; set; }
        public int SoSanPhamLamThem { get; set; }
        public decimal LuongSanPham { get; set; }
        public decimal LuongCongNhat { get; set; }
        public int LoaiTangCaID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TangCaEntity, TangCaDto>();
        }
    }
}
