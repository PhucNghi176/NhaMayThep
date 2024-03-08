using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CapBacLuong
{
    public class CapBacLuongDto : IMapFrom<CapBacLuongEntity>
    {
        public CapBacLuongDto() { }
        public int Id { get; set; }
        public string TenCapBac { get; set; }
        public float HeSoLuong { get; set; }
        public static CapBacLuongDto CreateCapBacLuong(int id, string tenCapBac, float heSoLuong)
        {
            return new CapBacLuongDto()
            {
                Id = id,
                TenCapBac = tenCapBac,
                HeSoLuong = heSoLuong
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CapBacLuongEntity, CapBacLuongDto>();
        }
    }
}
