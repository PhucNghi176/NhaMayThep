using MediatR;

using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhiCongDoan.Create
{
    public class CreatePhiCongDoanCommand : IRequest<string>, ICommand
    {
        public CreatePhiCongDoanCommand(string maSoNhanVien, double phanTramLuongDongBH, decimal luongDongBH)
        {

            MaSoNhanVien = maSoNhanVien;
            PhanTramLuongDongBH = phanTramLuongDongBH;
            LuongDongBH = luongDongBH;
        }


        public string MaSoNhanVien { get; set; }
        public double PhanTramLuongDongBH { get; set; }

        public decimal LuongDongBH { get; set; }
    }
}
