using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.ThongTinGiamTru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec
{
    public class TinhTrangLamViecDTO : IMapFrom<TinhTrangLamViecEntity>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        public TinhTrangLamViecDTO() { }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TinhTrangLamViecEntity, TinhTrangLamViecDTO>();   
        }
        public static TinhTrangLamViecDTO Create(int id, string TenMaTinhTrangLamViec)
        {
            return new TinhTrangLamViecDTO
            {
                ID = id,
                Name = TenMaTinhTrangLamViec,
            };
        }
    }
}
