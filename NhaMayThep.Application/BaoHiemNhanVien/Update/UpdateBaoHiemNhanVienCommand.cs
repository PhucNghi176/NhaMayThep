using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;

namespace NhaMayThep.Application.BaoHiemNhanVien.Update
{
    public class UpdateBaoHiemNhanVienCommand : IRequest<string>, ICommand
    {
        public UpdateBaoHiemNhanVienCommand(string id, string maSoNhanVien, int baoHiem)
        {
            Id = id;
            MaSoNhanVien = maSoNhanVien;
            BaoHiem = baoHiem;
        }

        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public int BaoHiem { get; set; }
    }
}
