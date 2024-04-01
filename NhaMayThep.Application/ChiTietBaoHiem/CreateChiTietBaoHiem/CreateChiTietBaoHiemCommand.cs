using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.CreateChiTietBaoHiem
{
    public class CreateChiTietBaoHiemCommand: IRequest<string>, ICommand
    {
        public CreateChiTietBaoHiemCommand(
            int loaibaohiem,
            DateTime ngayhieuluc,
            DateTime ngayketthuc,
            string noicap) 
        {
            LoaiBaoHiem = loaibaohiem;
            NgayHieuLuc = ngayhieuluc;
            NgayKetThuc = ngayketthuc;
            NoiCap = noicap;
        }
        public int LoaiBaoHiem { get;set; }
        public DateTime NgayHieuLuc { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string NoiCap { get; set; }
    }
}
