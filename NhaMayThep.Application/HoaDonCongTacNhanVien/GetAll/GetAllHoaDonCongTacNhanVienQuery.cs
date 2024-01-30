using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetAll
{
    public class GetAllHoaDonCongTacNhanVienQuery : IRequest<List<HoaDonCongTacNhanVienDto>>,IQuery
    {
        public GetAllHoaDonCongTacNhanVienQuery()
        {
            
        }
    }
}
