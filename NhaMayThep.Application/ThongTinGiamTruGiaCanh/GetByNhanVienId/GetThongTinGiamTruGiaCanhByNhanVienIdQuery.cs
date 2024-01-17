using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByNhanVienId
{
<<<<<<< HEAD:NhaMayThep.Application/ThongTinGiamTruGiaCanh/GetByNhanVienId/GetThongTinGiamTruGiaCanhByNhanVienIdQuery.cs
    public class GetThongTinGiamTruGiaCanhByNhanVienIdQuery: IRequest<List<ThongTinGiamTruGiaCanhDto>>, IQuery
=======
    public class GetThonTinGiamTruGiaCanhByNhanVienIdQuery : IRequest<List<ThongTinGiamTruGiaCanhDto>>, IQuery
>>>>>>> origin/main:NhaMayThep.Application/ThongTinGiamTruGiaCanh/GetByNhanVienId/GetThonTinGiamTruGiaCanhByNhanVienIdQuery.cs
    {
        public GetThongTinGiamTruGiaCanhByNhanVienIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
