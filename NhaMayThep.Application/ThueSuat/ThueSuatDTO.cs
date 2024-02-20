using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.TinhTrangLamViec;
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
        public string Name {  get; set; }
        public int BacThue { get; set; }
        public decimal ThuNhapTinhThueTrenNam { get; set; }
        public decimal ThuNhapTinhThueTrenThang { get; set; }
        public double PhanTramThueSuat { get; set; }
        public ThueSuatDTO() { }
        public ThueSuatDTO(int ID, string Name, int bacThue, decimal thuNhapTinhThueTrenNam, decimal thuNhapTinhThueTrenThang, double phanTramThueSuat)
        {
            this.ID = ID;
            this.Name = Name;
            this.BacThue = bacThue;
            this.ThuNhapTinhThueTrenNam = thuNhapTinhThueTrenNam;
            this.ThuNhapTinhThueTrenThang = thuNhapTinhThueTrenThang;
            this.PhanTramThueSuat = phanTramThueSuat;
        }


        public static ThueSuatDTO Create(int id, string Name, int bacThue, decimal thuNhapTinhThueTrenNam, decimal thuNhapTinhThueTrenThang, double phanTramThueSuat)
        {
            return new ThueSuatDTO
            {
                ID = id,
                Name = Name,
                BacThue = bacThue,
                ThuNhapTinhThueTrenNam = thuNhapTinhThueTrenNam,
                ThuNhapTinhThueTrenThang = thuNhapTinhThueTrenThang,
                PhanTramThueSuat = phanTramThueSuat,
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThueSuatEntity, ThueSuatDTO>();
        }

    }
}
