using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietDangVien.GetByNhanVienIDChiTietDangVien
{
    public class GetByNhanVienIDChiTietDangVienCommand : IRequest<ChiTietDangVienDto>
    {
        public GetByNhanVienIDChiTietDangVienCommand(string nhanVienID)
        {
            NhanVienID = nhanVienID;
        }

        public string NhanVienID { get; set; }
    }
}
