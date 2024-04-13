using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVuDang.CreateThongTinChucVuDang
{
    public class CreateThongTinChucVuDangCommand : IRequest<string>, ICommand
    {
        public string TenChucVuDang { get; set; }
        public string ChucVuDang { get; set; }
        public CreateThongTinChucVuDangCommand(string tenChucVuDang, string chucVuDang)
        {
            TenChucVuDang = tenChucVuDang;
            ChucVuDang = chucVuDang;
        }
    }
}
