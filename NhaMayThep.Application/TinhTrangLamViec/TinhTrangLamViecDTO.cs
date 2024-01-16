using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec
{
    public class TinhTrangLamViecDTO
    {
        public int ID { get; set; }
        public string TenMaTinhTrangLamViec { get; set; }
        public string NguoiTaoID { get; set; }
        public DateTime NgayTao { get; set; }
        public string NguoiCapNhatID { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string NguoiXoaID { get; set; }
        public DateTime NgayXoa { get; set; }
        public TinhTrangLamViecDTO() { }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TinhTrangLamViecEntity, TinhTrangLamViecDTO>();   
        }
    }
}
