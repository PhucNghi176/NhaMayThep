using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVuDang.UpdateThongTinChucVuDang
{
    public class UpdateThongTinChucVuDangCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string TenChucVuDang { get; set; }
        public UpdateThongTinChucVuDangCommand(int id, string tenChucVuDang)
        {
            Id = id;
            TenChucVuDang = tenChucVuDang;
        }
    }
}
