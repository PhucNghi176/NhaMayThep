using MediatR;
using NhaMayThep.Application.DonViCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.DeleteThongTinDangVien
{
    public class DeleteThongTinDangVienCommand : IRequest<string>
    {
        public DeleteThongTinDangVienCommand(string id )
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}
