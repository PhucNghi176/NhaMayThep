using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Create
{
    public class CreateCommand : IRequest<ChiTietNgayNghiPhepDto>, ICommand
    {
        public string MaSoNhanVien { get; set; }
        public int LoaiNghiPhep { get; set; }
        public int TongSoGio { get; set; }
        public int SoGioDaNghiPhep { get; set; }
        public int SoGioConLai { get; set; }
        public int NamHieuLuoc { get; set; }


    }
}
