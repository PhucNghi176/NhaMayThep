using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.UpdateTinhTrangLamViec
{
    public class UpdateTinhTrangLamViecCommand : IRequest<TinhTrangLamViecDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NguoiCapNhatID { get; set; }
        public UpdateTinhTrangLamViecCommand(int id, string name, string nguoiCapNhatID)
        {
            Id = id;
            Name = name;
            NguoiCapNhatID = nguoiCapNhatID;
        }
    }
}
