using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.UpdateThongTinGiamTru
{
    public class UpdateThongTinGiamTruCommand :IRequest<ThongTinGiamTruDTO>,ICommand
    {
        public int ID { get; set; }
        public string TenMaGiamTru {  get; set; }
        public decimal SoTienGiamTru { get; set; }
        public UpdateThongTinGiamTruCommand() { }
        public UpdateThongTinGiamTruCommand(string NguoiCapNhatID,int iD, string tenMaGiamTru, decimal soTienGiamTru)
        {
            this.ID = iD;
            this.TenMaGiamTru = tenMaGiamTru;
            this.SoTienGiamTru = soTienGiamTru;
        }
    }
}
