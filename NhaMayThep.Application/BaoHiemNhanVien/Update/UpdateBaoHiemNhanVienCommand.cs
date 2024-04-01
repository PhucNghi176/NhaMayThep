using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;

namespace NhaMayThep.Application.BaoHiemNhanVien.Update
{
    public class UpdateBaoHiemNhanVienCommand : IRequest<string>, ICommand
    {
        public UpdateBaoHiemNhanVienCommand(int id, string maSoNhanVien)
        {
            Id = id;
            MaSoNhanVien = maSoNhanVien;
        }

        public int Id { get; set; }
        public string MaSoNhanVien { get; set; }
    }
}
