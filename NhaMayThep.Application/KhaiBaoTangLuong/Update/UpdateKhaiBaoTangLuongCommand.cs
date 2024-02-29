using MediatR;
using System;
using System.Collections.Generic;
using NhaMayThep.Application.Common.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Update
{
    public class UpdateKhaiBaoTangLuongCommand : IRequest<string>, ICommand
    {
        public required string MaSoNhanVien { get; set; }
        public float PhanTramTang { get; set; }
        public DateTime NgayApDung { get; set; }
        public string LyDo { get; set; }
        public string ID { get; set; }
        public UpdateKhaiBaoTangLuongCommand(string Id, string maSoNhanVien, float phanTramTang, DateTime ngayApDung, string lyDo)
        {
            ID = Id;
            MaSoNhanVien = maSoNhanVien;
            PhanTramTang = phanTramTang;
            NgayApDung = ngayApDung;
            LyDo = lyDo;
        }
        public UpdateKhaiBaoTangLuongCommand() { }
    }
}
