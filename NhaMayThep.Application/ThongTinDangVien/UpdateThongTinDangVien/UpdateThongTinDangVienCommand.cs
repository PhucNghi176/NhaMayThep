using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien
{
    public class UpdateThongTinDangVienCommand : IRequest<ThongTinDangVienDto>, ICommand
    {
        public UpdateThongTinDangVienCommand(string id, string nhanVienId, DateTime ngayVaoDang, string capDangVien, string nguoiCapNhatId)
        {
            ID = id;
            NhanVienID = nhanVienId;
            NgayVaoDang = ngayVaoDang;
            CapDangVien = capDangVien;
            NguoiCapNhatID = nguoiCapNhatId;
        }

        public string ID { get; set; }
        public string NhanVienID { get; set; }

        public DateTime NgayVaoDang { get; set; }
        public string CapDangVien { get; set; }

        public string? NguoiCapNhatID { get; set; }
    }
}
