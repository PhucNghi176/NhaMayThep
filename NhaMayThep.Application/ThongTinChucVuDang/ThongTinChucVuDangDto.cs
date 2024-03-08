using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVuDang
{
    public class ThongTinChucVuDangDto : IMapFrom<ThongTinChucVuDangEntity>
    {
        public ThongTinChucVuDangDto() { }
        public int Id { get; set; }
        public string TenChucVuDang { get; set; }
        public string ChucVuDang { get; set; }
        public static ThongTinChucVuDangDto CreateThongTinChucVuDang(int id, string tenChucVuDang, string chucVuDang)
        {
            return new ThongTinChucVuDangDto()
            {
                Id = id,
                TenChucVuDang = tenChucVuDang,
                ChucVuDang = chucVuDang
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinChucVuDangEntity, ThongTinChucVuDangDto>();
        }
    }
}
