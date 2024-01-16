using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Update
{
    public class UpdateChiTietNghiPhepCommand : IRequest<ChiTietNgayNghiPhepDto>,ICommand
    {
        public string Id { get; set; } // Use this as the primary key
        
        public int LoaiNghiPhep { get; set; }
        public int TongSoGio { get; set; }
        public int SoGioDaNghiPhep { get; set; }
        public int SoGioConLai { get; set; }
        public int NamHieuLuoc { get; set; }
    }
}
