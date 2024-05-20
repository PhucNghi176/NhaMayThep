using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThueSuat.UpdateThueSuat
{
    public class UpdateThueSuatCommand : IRequest<string>, ICommand
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BacThue { get; set; }
        public decimal DauThuNhapTinhThueTrenNam { get; set; }
        public decimal CuoiThuNhapTinhThueTrenNam { get; set; }
        public decimal DauThuNhapTinhThueTrenThang { get; set; }
        public decimal CuoiThuNhapTinhThueTrenThang { get; set; }
        public double PhanTramThueSuat { get; set; }
        public UpdateThueSuatCommand(int iD, string name, int bacThue, decimal dauThuNhapTinhThueTrenNam, decimal cuoiThuNhapTinhThueTrenNam, decimal dauthuNhapTinhThueTrenThang, decimal cuoithuNhapTinhThueTrenThang, double phanTramThueSuat)
        {
            ID = iD;
            Name = name;
            BacThue = bacThue;
            DauThuNhapTinhThueTrenNam = dauThuNhapTinhThueTrenNam;
            CuoiThuNhapTinhThueTrenNam = cuoiThuNhapTinhThueTrenNam;
            DauThuNhapTinhThueTrenThang = dauthuNhapTinhThueTrenThang;
            CuoiThuNhapTinhThueTrenThang = cuoithuNhapTinhThueTrenThang;
            PhanTramThueSuat = phanTramThueSuat;
        }
        public UpdateThueSuatCommand() { }
    }
}
