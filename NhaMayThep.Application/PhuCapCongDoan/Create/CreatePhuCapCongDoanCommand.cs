using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhuCapCongDoan.Create
{
    public class CreatePhuCapCongDoanCommand : IRequest<string>, ICommand
    {
        public CreatePhuCapCongDoanCommand(int soLuongDoanVien, float heSoPhuCap, string donVi)
        {
            SoLuongDoanVien = soLuongDoanVien;
            HeSoPhuCap = heSoPhuCap;
            DonVi = donVi;
        }
        public int SoLuongDoanVien { get; set; }
        public float HeSoPhuCap { get; set; }
        public string DonVi { get; set; }
    }
}
