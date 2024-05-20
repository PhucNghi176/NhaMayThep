using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.GetById
{
    public class GetThongTinLuongNhanVienByIdQuery : IRequest<ThongTinLuongNhanVienDTO>, IQuery
    {
        public string Id { get; set; }
        public GetThongTinLuongNhanVienByIdQuery(string id)
        {
            Id = id;
        }
    }
}
