using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.CanCuocCongDan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CapBacLuong
{
    public class CapbacLuongDto : IMapFrom<CapBacLuongEntity>
    {
        public string Name { get; set; }
        public string NguoiTaoID { get; set; }
        public DateTime NgayTao { get; set; }
        public string NguoiCapNhatID { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string NguoiXoaID { get; set; }
        public DateTime NgayXoa { get; set; }
        public float HeSoLuong { get; set; }

        public static CapbacLuongDto Create(int id, string name, string nguoitaoid, DateTime ngaytao, string nguoicapnhatid, DateTime ngaycapnhat, string nguoixoaid, DateTime ngayxoa, float hesoluong) 
        {
            return new CapbacLuongDto
            {
                HeSoLuong = hesoluong,
                Name = name,
                NgayCapNhat = ngaytao,
                NguoiTaoID = nguoicapnhatid,
                NgayTao = ngaytao,
                NgayXoa = ngayxoa,
                NguoiCapNhatID = nguoicapnhatid
            };

        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CapBacLuongEntity, CapbacLuongDto>();
        }
    }
}
