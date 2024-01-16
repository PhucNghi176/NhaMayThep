using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.UpdateThongTinGiamTru
{
    public class UpdateThongTinGiamTruCommand :IRequest<ThongTinGiamTruDTO>
    {
        public int ID { get; set; }
        public string TenMaGiamTru {  get; set; }
        public decimal SoTienGiamTru { get; set; }
        public string NguoiCapNhatID { get; set; }

        public UpdateThongTinGiamTruCommand(string NguoiCapNhatID,int iD, string tenMaGiamTru, decimal soTienGiamTru)
        {
            this.NguoiCapNhatID = NguoiCapNhatID;
            this.ID = iD;
            this.TenMaGiamTru = tenMaGiamTru;
            this.SoTienGiamTru = soTienGiamTru;
        }
    }
}
