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
    public class UpdateThongTinDangVienCommand : IRequest<ThongTinDangVienDto>, ICommand
    {
        public UpdateThongTinDangVienCommand(DateTime ngayVaoDang, string capDangVien )
        {
            NgayVaoDang = ngayVaoDang;
            CapDangVien = capDangVien;
        }

        public void RouteNhanVienID(string value)
        {
            NhanVienID = value;
        }

        public string NhanVienId { get { return NhanVienID; } }
        private string NhanVienID;

        public DateTime NgayVaoDang { get; set; }
        public string CapDangVien { get; set; }

    }
}
