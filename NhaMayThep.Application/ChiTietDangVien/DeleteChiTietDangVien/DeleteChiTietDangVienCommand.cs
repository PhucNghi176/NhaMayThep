using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietDangVien.DeleteChiTietDangVien
{
    public class DeleteChiTietDangVienCommand : IRequest<string>, ICommand
    {
        public DeleteChiTietDangVienCommand(string id, string? nguoiXoaID)
        {
            ID = id;
            NguoiXoaID = nguoiXoaID;
        }

        public string ID { get; set; }
        public string? NguoiXoaID { get; set; }
    }
}
