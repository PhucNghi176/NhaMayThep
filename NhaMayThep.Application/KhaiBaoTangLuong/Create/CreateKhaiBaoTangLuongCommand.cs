using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NhaMayThep.Application.Common.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Create
{
    public class CreateKhaiBaoTangLuongCommand : IRequest<string>, ICommand
    {
        public CreateKhaiBaoTangLuongCommand(string id, string maSoNhanVien, float phanTramTang, DateTime ngayApDung, string lyDo)
        {
            ID = id;
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