using MediatR;
using NhaMayThep.Application.DonViCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.DeleteThongTinDangVien
{
    public class DeleteThongTinDangVienCommand : IRequest<ThongTinDangVienDto>
    {
        public DeleteThongTinDangVienCommand(string id, string? nguoiXoaID)
        {
            ID = id;
            NguoiXoaID = nguoiXoaID;
        }

        public string ID { get; set; }
        public string? NguoiXoaID { get; set; }
    }
}
