using MediatR;

namespace NhaMayThep.Application.MaDangKiCaLamViec.GetAll
{
    public class GetAllMaDangKiCaLamQuery : IRequest<List<MaDangKiCaLamViecDTO>>
    {
        public GetAllMaDangKiCaLamQuery() { }
    }
}
