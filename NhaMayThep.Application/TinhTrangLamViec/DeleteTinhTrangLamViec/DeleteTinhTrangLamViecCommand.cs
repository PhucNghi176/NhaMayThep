using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.DeleteTinhTrangLamViec
{
    public class DeleteTinhTrangLamViecCommand : IRequest<TinhTrangLamViecDTO>
    {
        public int Id { get; set; }
        public string NguoiXoaID {  get; set; }
        public DeleteTinhTrangLamViecCommand(int id, string nguoiXoaID)
        {
            Id = id;
            NguoiXoaID = nguoiXoaID;
        }
    }
}
