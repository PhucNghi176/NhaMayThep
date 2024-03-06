using MediatR;

namespace NhaMayThep.Application.DangKiCaLam.Queries.GetDangKiCaLamById
{
    public class GetDangKiCaLamByIdQuery : IRequest<DangKiCaLamDto>
    {
        public string Id { get; set; }

        public GetDangKiCaLamByIdQuery(string id)
        {
            Id = id;
        }
    }
}
