using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThueSuat
{
    public class ThueSuatDTO : IMapFrom<ThueSuatEntity>
    {
        public int ID {  get; set; }
        public string name {  get; set; }
        public int BacThue { get; set; }
        public decimal ThuNhapTinhThueTrenNam { get; set; }
        public decimal ThuNhapTinhThueTrenThang { get; set; }
        public decimal PhanTramThueSuat { get; set; }
        public ThueSuatDTO() { }
        public ThueSuatDTO(int ID, string Name, int bacThue, decimal thuNhapTinhThueTrenNam, decimal thuNhapTinhThueTrenThang, decimal phanTramThueSuat)
        {
            this.ID = ID;
            this.name = Name;
            this.BacThue = bacThue;
            this.ThuNhapTinhThueTrenNam = thuNhapTinhThueTrenNam;
            this.ThuNhapTinhThueTrenThang = thuNhapTinhThueTrenThang;
            this.PhanTramThueSuat = phanTramThueSuat;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThueSuatEntity, ThueSuatDTO>();
        }

    }
}
