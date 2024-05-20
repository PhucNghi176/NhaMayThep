using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhiCongDoan.Update
{
    public class UpdatePhiCongDoanCommand : IRequest<string>, ICommand
    {
        public UpdatePhiCongDoanCommand(string id, string maSoNhanVien, double phanTramLuongDongBH, decimal luongDongBH)
        {
            Id = id;
            MaSoNhanVien = maSoNhanVien;
            PhanTramLuongDongBH = phanTramLuongDongBH;
            LuongDongBH = luongDongBH;
        }

        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public double PhanTramLuongDongBH { get; set; }

        public decimal LuongDongBH { get; set; }
    }

}
