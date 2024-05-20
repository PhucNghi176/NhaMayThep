using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.ThueSuat
{
    public class ThueSuatDTO : IMapFrom<ThueSuatEntity>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BacThue { get; set; }
        public decimal DauThuNhapTinhThueTrenNam { get; set; }
        public decimal CuoiThuNhapTinhThueTrenNam { get; set; }
        public decimal DauThuNhapTinhThueTrenThang { get; set; }
        public decimal CuoiThuNhapTinhThueTrenThang { get; set; }
        public double PhanTramThueSuat { get; set; }
        public ThueSuatDTO() { }
        public ThueSuatDTO(int ID, string Name, int bacThue, decimal dauThuNhapTinhThueTrenNam, decimal cuoiThuNhapTinhThueTrenNam, decimal dauthuNhapTinhThueTrenThang, decimal cuoithuNhapTinhThueTrenThang, double phanTramThueSuat)
        {
            this.ID = ID;
            this.Name = Name;
            this.BacThue = bacThue;
            this.DauThuNhapTinhThueTrenNam = dauThuNhapTinhThueTrenNam;
            this.CuoiThuNhapTinhThueTrenNam = cuoiThuNhapTinhThueTrenNam;
            this.DauThuNhapTinhThueTrenThang = dauthuNhapTinhThueTrenThang;
            this.CuoiThuNhapTinhThueTrenThang = cuoithuNhapTinhThueTrenThang;
            this.PhanTramThueSuat = phanTramThueSuat;
        }


        public static ThueSuatDTO Create(int id, string Name, int bacThue, decimal dauThuNhapTinhThueTrenNam, decimal cuoiThuNhapTinhThueTrenNam, decimal dauthuNhapTinhThueTrenThang, decimal cuoithuNhapTinhThueTrenThang, double phanTramThueSuat)
        {
            return new ThueSuatDTO
            {
                ID = id,
                Name = Name,
                BacThue = bacThue,
                DauThuNhapTinhThueTrenNam = dauThuNhapTinhThueTrenNam,
                CuoiThuNhapTinhThueTrenNam = cuoiThuNhapTinhThueTrenNam,
                DauThuNhapTinhThueTrenThang = dauthuNhapTinhThueTrenThang,
                CuoiThuNhapTinhThueTrenThang = cuoithuNhapTinhThueTrenThang,
                PhanTramThueSuat = phanTramThueSuat,
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThueSuatEntity, ThueSuatDTO>();
        }

    }
}
