using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien
{
    public class UpdateThongTinDangVienCommand : IRequest<string>, ICommand
    {
        public UpdateThongTinDangVienCommand(string nhanvienId, DateTime ngayVaoDang, string capDangVien )
        {
            NhanVienID = nhanvienId;
            NgayVaoDang = ngayVaoDang;
            CapDangVien = capDangVien;
        }
        public string NhanVienID { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public string CapDangVien { get; set; }

    }
}
