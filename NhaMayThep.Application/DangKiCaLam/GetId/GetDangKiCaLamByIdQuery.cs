using MediatR;

namespace NhaMayThep.Application.DangKiCaLam.Queries.GetDangKiCaLamById
{
    public class GetDangKiCaLamByIdQuery : IRequest<DangKiCaLamDto>
    {
        public int MaCaLamViec { get; set; }

        public GetDangKiCaLamByIdQuery(int maCaLamViec)
        {
            MaCaLamViec = maCaLamViec;
        }
    }
}
