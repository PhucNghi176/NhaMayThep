using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.HopDong;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat
{
    public class KyLuatDTO : IMapFrom<KyLuatEntity>
    {
       
        public KyLuatDTO() { }
       /*
        public static KyLuatDTO Create(string ID,string MaSoNhanVien, string ChinhSachNhanSuID, string TenDotKyLuat, DateTime NgayKiLuat, decimal TongPhat)
        {
            return new KyLuatDTO()
            {
                this.Id = ID,
                this.MaSoNhanVien = MaSoNhanVien,
                this.ChinhSachNhanSuID = ChinhSachNhanSuID,
                this.TenDotKyLuat = TenDotKyLuat,
                this.NgayKiLuat = NgayKiLuat,
                this.TongPhat = TongPhat
            };
        }
        */
        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public string tenNhanVien { get; set; } 
        public int ChinhSachNhanSuID { get; set; }
        public string TenDotKyLuat { get; set; }
        public DateTime NgayKiLuat { get; set; }
        public decimal TongPhat { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<KyLuatEntity, KyLuatDTO>();
        }
    }
}
