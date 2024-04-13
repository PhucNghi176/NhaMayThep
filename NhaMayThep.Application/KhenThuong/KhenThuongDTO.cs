using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong
{
    public class KhenThuongDTO : IMapFrom<KhenThuongEntity>
    {
        public string MaSoNhanVien { get; set; }
        public string ID {  get; set; }
        public int ChinhSachNhanSuID { get; set; }
        public string TenDotKhenThuong { get; set; }
        public DateTime NgayKhenThuong { get; set; }
        public decimal TongThuong { get; set; }
        public KhenThuongDTO() { }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<KhenThuongEntity, KhenThuongDTO>();
        }
    }
}
