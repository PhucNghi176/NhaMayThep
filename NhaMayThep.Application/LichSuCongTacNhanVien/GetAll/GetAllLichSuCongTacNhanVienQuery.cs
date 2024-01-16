using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.GetAll
{
    public class GetAllLichSuCongTacNhanVienQuery : IRequest<List<LichSuCongTacNhanVienDto>>
    {
        public GetAllLichSuCongTacNhanVienQuery() { }
    }
}
