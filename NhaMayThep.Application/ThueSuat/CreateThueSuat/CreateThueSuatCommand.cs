using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThueSuat.CreateThueSuat
{
    public class CreateThueSuatCommand : IRequest<string>, ICommand
    {
        public string name {  get; set; }
        public int BacThue { get; set; }
        public decimal ThuNhapTinhThueTrenNam { get; set; }
        public decimal ThuNhapTinhThueTrenThang { get; set; }
        public double PhanTramThueSuat { get; set; }
        public CreateThueSuatCommand(string name, int bacThue, decimal thuNhapTinhThueTrenNam, decimal thuNhapTinhThueTrenThang, double phanTramThueSuat)
        {
            this.name = name;
            this.BacThue = bacThue;
            this.ThuNhapTinhThueTrenNam = thuNhapTinhThueTrenNam;
            this.ThuNhapTinhThueTrenThang = thuNhapTinhThueTrenThang;
            this.PhanTramThueSuat = phanTramThueSuat;
        }
        public CreateThueSuatCommand() { }
    }
}
