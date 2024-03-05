using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.MucSanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu
{
    public class ChinhSachNhanSuDto : IMapFrom<ChinhSachNhanSuEntity>
    {
        public ChinhSachNhanSuDto()
        {
            
        }
        public int ID {  get; set; }
        public string Name { get; set; }
        public string MucDo { get; set; } 
        public DateTime NgayHieuLuc {  get; set; }
        public string NoiDung {  get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChinhSachNhanSuEntity, ChinhSachNhanSuDto>();
        }
    }
}
