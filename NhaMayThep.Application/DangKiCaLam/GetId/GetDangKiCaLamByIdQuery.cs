using MediatR;

namespace NhaMayThep.Application.DangKiCaLam.GetId
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
