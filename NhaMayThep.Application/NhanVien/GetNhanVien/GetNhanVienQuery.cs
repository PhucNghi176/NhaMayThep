using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetNhanVien
{
    public class GetNhanVienQuery : IRequest<NhanVienDto>, IQuery
    {
        public GetNhanVienQuery()
        {
            
        }
        public GetNhanVienQuery(string predicate)
        {
            Predicate = predicate;
        }

        public required string Predicate { get; set; }
    }
}
