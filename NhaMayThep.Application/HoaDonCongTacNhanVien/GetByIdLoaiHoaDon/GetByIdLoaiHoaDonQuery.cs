using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetByIdLoaiHoaDon
{
    public class GetByIdLoaiHoaDonQuery : IRequest<List<HoaDonCongTacNhanVienDto>>, IQuery
    {

        public GetByIdLoaiHoaDonQuery()
        {

        }

        public GetByIdLoaiHoaDonQuery(int idLoaiHoaDon, int year, int month)
        {
            this.idLoaiHoaDon = idLoaiHoaDon;
            this.year = year;
            this.month = month;
        }

        public int idLoaiHoaDon { get; set; }
        public int year { get; set; }
        public int month { get; set; }
    }
}