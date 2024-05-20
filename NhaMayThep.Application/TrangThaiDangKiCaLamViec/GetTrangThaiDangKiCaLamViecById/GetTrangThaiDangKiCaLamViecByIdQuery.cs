using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.GetTrangThaiDangKiCaLamViecById
{
    public class GetTrangThaiDangKiCaLamViecByIdQuery : IRequest<TrangThaiDangKiCaLamViecDTO>, IQuery
    {
        public GetTrangThaiDangKiCaLamViecByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
