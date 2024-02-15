using MediatR;
using System;
using System.Collections.Generic;
using NhaMayThep.Application.Common.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
