using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru
{
    public class ThongTinGiamTruDTO
    {
        public int Id { get; set; }
        public string TenMaGiamTru { get; set; }
        public decimal SoTienGiamTru { get; set; }
        public string NguoiTaoID { get; set; }
        public DateTime NgayTao {  get; set; }
        public string NguoiCapNhatID {  get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string NguoiXoaID {  get; set; }
        public DateTime NgayXoa { get; set; }
        public ThongTinGiamTruDTO() { }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinGiamTruEntity,ThongTinGiamTruDTO>();
        }
    }
}
