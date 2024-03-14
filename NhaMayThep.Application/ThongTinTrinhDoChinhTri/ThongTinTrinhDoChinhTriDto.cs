using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri
{
    public class ThongTinTrinhDoChinhTriDto : IMapFrom<ThongTinTrinhDoChinhTriEntity>
    {
        public ThongTinTrinhDoChinhTriDto() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrinhDoChinhTri { get; set; }
        public static ThongTinTrinhDoChinhTriDto CreateThongTinTrinhDoChinhTri(int id, string name, int trinhDoChinhTri)
        {
            return new ThongTinTrinhDoChinhTriDto()
            {
                Id = id,
                Name = name,
                TrinhDoChinhTri = trinhDoChinhTri
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinTrinhDoChinhTriEntity, ThongTinTrinhDoChinhTriDto>();
        }
    }
}
