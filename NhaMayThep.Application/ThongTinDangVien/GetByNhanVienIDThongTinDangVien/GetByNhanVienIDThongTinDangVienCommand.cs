using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.GetByNhanVienIDThongTinDangVien
{
    public class GetByNhanVienIDThongTinDangVienCommand : IRequest<List<ThongTinDangVienDto>>
    {
        public GetByNhanVienIDThongTinDangVienCommand(string nhanVienID)
        {
            NhanVienID = nhanVienID;
        }

        public string NhanVienID { get; set; }
    }
}
