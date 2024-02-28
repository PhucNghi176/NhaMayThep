using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.DeleteChiTietBaoHiem
{
    public class DeleteChiTietBaoHiemCommandHandler : IRequestHandler<DeleteChiTietBaoHiemCommand, string>
    {
        public Task<string> Handle(DeleteChiTietBaoHiemCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
