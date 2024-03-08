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
        public decimal DauThuNhapTinhThueTrenNam { get; set; }
        public decimal CuoiThuNhapTinhThueTrenNam { get; set; }
        public decimal DauThuNhapTinhThueTrenThang { get; set; }
        public decimal CuoiThuNhapTinhThueTrenThang { get; set; }
        public double PhanTramThueSuat { get; set; }
        public CreateThueSuatCommand(string name, int bacThue, decimal dauThuNhapTinhThueTrenNam, decimal cuoiThuNhapTinhThueTrenNam, decimal dauthuNhapTinhThueTrenThang, decimal cuoithuNhapTinhThueTrenThang, double phanTramThueSuat)
        {
            this.name = name;
            this.BacThue = bacThue;
            this.DauThuNhapTinhThueTrenNam = dauThuNhapTinhThueTrenNam;
            this.CuoiThuNhapTinhThueTrenNam = cuoiThuNhapTinhThueTrenNam;
            this.DauThuNhapTinhThueTrenThang = dauthuNhapTinhThueTrenThang;
            this.CuoiThuNhapTinhThueTrenThang = cuoithuNhapTinhThueTrenThang;
            this.PhanTramThueSuat = phanTramThueSuat;
        }
        public CreateThueSuatCommand() { }
    }
}
