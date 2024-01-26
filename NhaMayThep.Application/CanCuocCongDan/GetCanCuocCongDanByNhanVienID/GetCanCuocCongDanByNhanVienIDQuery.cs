using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CanCuocCongDan.GetCanCuocCongDanByNhanVienID
{
    public class GetCanCuocCongDanByNhanVienIDQuery : IRequest<CanCuocCongDanDto>, IQuery
    {
        public required string NhanVienID { get; set; }
        public GetCanCuocCongDanByNhanVienIDQuery(string nhanVienID)
        {
            NhanVienID = nhanVienID;
        }
        public GetCanCuocCongDanByNhanVienIDQuery()
        {
            
        }
    }
}
