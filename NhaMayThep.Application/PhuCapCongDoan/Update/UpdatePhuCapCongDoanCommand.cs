using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhuCapCongDoan.Update
{
    public class UpdatePhuCapCongDoanCommand : IRequest<string>, ICommand
    {
        public UpdatePhuCapCongDoanCommand(string id, int soLuongDoanVien, float heSoPhuCap, string donVi)
        {
            ID = id;
            SoLuongDoanVien = soLuongDoanVien;
            HeSoPhuCap = heSoPhuCap;
            DonVi = donVi;
        }
        public string ID { get; set; }
        public int SoLuongDoanVien { get; set; }
        public float HeSoPhuCap { get; set; }
        public string DonVi { get; set; }
    }
}
