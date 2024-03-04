using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.QuaTrinhNhanSu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MucSanPham
{
    public class MucSanPhamDto : IMapFrom<MucSanPhamEntity>
    {
        public MucSanPhamDto()
        {
            
        }
        public string ID {  get; set; }
        public int MucSanPhamToiThieu {  get; set; }
        public int MucSanPhamToiDa {  get; set; }
        public decimal LuongMucSanPham {  get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MucSanPhamEntity, MucSanPhamDto>();
        }
    }
}
