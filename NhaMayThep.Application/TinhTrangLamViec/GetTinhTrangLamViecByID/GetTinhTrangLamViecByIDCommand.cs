using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.GetTinhTrangLamViecByID
{
    public class GetTinhTrangLamViecByIDCommand : IRequest<TinhTrangLamViecDTO>
    {
        public int id {  get; set; }
        public GetTinhTrangLamViecByIDCommand(int id)
        {
            this.id = id;
        }
    }
}
