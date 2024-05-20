using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.GetAllTrangThaiDangKiCaLamViec
{
    public class GetAllTrangThaiDangKiCaLamViecQuery : IRequest<List<TrangThaiDangKiCaLamViecDTO>>, IQuery
    {
        public GetAllTrangThaiDangKiCaLamViecQuery() { }
    }
}
