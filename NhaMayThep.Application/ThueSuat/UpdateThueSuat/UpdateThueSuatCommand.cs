using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThueSuat.UpdateThueSuat
{
    public class UpdateThueSuatCommand : IRequest<string>, ICommand
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BacThue { get; set; }
        public decimal ThuNhapTinhThueTrenNam { get; set; }
        public decimal ThuNhapTinhThueTrenThang { get; set; }
        public decimal PhanTramThueSuat { get; set; }
        public UpdateThueSuatCommand(int iD, string name, int bacThue, decimal thuNhapTinhThueTrenNam, decimal thuNhapTinhThueTrenThang, decimal phanTramThueSuat)
        {
            ID = iD;
            Name = name;
            BacThue = bacThue;
            ThuNhapTinhThueTrenNam = thuNhapTinhThueTrenNam;
            ThuNhapTinhThueTrenThang = thuNhapTinhThueTrenThang;
            PhanTramThueSuat = phanTramThueSuat;
        }
        public UpdateThueSuatCommand() { }
    }
}
