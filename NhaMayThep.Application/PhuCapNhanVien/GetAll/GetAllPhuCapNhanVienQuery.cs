using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhuCapNhanVien.GetAll
{
    public class GetAllPhuCapNhanVienQuery : IRequest<List<PhuCapNhanVienDto>>, IQuery
    {
        public GetAllPhuCapNhanVienQuery() { }
    }
}
