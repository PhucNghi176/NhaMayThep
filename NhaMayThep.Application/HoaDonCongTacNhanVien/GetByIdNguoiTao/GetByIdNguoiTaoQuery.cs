using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetByIdNguoiTao
{
    public class GetByIdNguoiTaoQuery : IRequest<List<HoaDonCongTacNhanVienDto>>, IQuery
    {
        public GetByIdNguoiTaoQuery()
        {

        }
        public GetByIdNguoiTaoQuery(string idNguoiTao)
        {
            this.idNguoiTao = idNguoiTao;
        }

        public string idNguoiTao { get; set; }
    }
}
