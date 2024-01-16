using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.GetAllTinhTrangLamViec
{
    public class GetAllTinhTrangLamViecCommand : IRequest<List<TinhTrangLamViecDTO>>
    {
    }
}
