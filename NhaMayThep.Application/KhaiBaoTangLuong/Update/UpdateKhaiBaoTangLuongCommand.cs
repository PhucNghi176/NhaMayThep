using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Update
{
    public class UpdateKhaiBaoTangLuongCommand : IRequest<KhaiBaoTangLuongDto>, ICommand
    {
        public UpdateKhaiBaoTangLuongCommand(Guid Id, Guid MaSoNhanVien, double PhanTramTang, DateTime NgayApDung, string LyDo)
        {
            this.Id = Id.ToString();
            this.MaSoNhanVien = MaSoNhanVien.ToString();
            this.PhanTramTang = PhanTramTang;
            this.NgayApDung = NgayApDung;
            this.LyDo = LyDo;
        }
        public string Id { get; set; }
        public string? MaSoNhanVien { get; set; }
        public double? PhanTramTang { get; set; }
        public DateTime? NgayApDung { get; set; }
        public string? LyDo { get; set; }
    }
}
