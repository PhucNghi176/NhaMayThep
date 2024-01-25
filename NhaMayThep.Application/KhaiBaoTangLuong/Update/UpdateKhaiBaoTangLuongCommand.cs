using MediatR;
using NhaMayThep.Application.KhaiBaoTangLuong;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Update
{
    public class UpdateKhaiBaoTangLuongCommand : IRequest<KhaiBaoTangLuongDto>, ICommand
    {
        public UpdateKhaiBaoTangLuongCommand(string maSoNhanVien, float phanTramTang, DateTime ngayApDung, string lyDo)
        {
            MaSoNhanVien = maSoNhanVien;
            PhanTramTang = phanTramTang;
            NgayApDung = ngayApDung;
            LyDo = lyDo;    
        }

        public string ID { get; set; }
        public required string MaSoNhanVien { get; set; }
        public float PhanTramTang { get; set; }
        public DateTime NgayApDung { get; set; }
        public string LyDo { get; set; }
    }
}
