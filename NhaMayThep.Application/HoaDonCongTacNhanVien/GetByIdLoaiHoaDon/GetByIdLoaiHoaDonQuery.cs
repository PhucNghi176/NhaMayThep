using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetByIdLoaiHoaDon
{
    public class GetByIdLoaiHoaDonQuery : IRequest<List<HoaDonCongTacNhanVienDto>>, IQuery
    {

        public GetByIdLoaiHoaDonQuery()
        {

        }

        public GetByIdLoaiHoaDonQuery(int idLoaiHoaDon, string year, int month)
        {
            this.idLoaiHoaDon = idLoaiHoaDon;
            this.year = year;
            this.month = month;
        }

        public int idLoaiHoaDon { get; set; }
        public string year { get; set; }
        public int month { get; set; }
    }
}
