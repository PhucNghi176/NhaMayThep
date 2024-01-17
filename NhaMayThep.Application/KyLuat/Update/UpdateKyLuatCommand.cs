using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.Update
{
    public class UpdateKyLuatCommand : IRequest<KyLuatDto>, ICommand
    {
        public UpdateKyLuatCommand () { }

        public string Id { get; set; }
        public string? HinhThucKyLuat { get; set; }
        public string? LoaiKyLuat { set; get; }
        public string? TenDotKyLuat { set; get; }
        public DateTime NgayKyLuat { set; get; }
        public double? TongPhat { set; get; }
        public string? DonViApDung { set; get; }

        public UpdateKyLuatCommand(string id, string hinhThucKyLuat, string loaiKyLuat, string tenDotKyLuat, DateTime ngayKyLuat, double tongPhat, string donViApDung)
        {
            Id = id;
            HinhThucKyLuat = hinhThucKyLuat;
            LoaiKyLuat = loaiKyLuat;
            TenDotKyLuat = tenDotKyLuat;
            NgayKyLuat = ngayKyLuat;
            TongPhat = tongPhat;
            DonViApDung = donViApDung;
        }
    }
}
