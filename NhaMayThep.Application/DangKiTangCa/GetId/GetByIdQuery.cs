using MediatR;

namespace NhaMayThep.Application.DangKiTangCa.GetId
{
    public class GetByIdQuery : IRequest<DangKiTangCaDto>
    {
        public string Id { get; set; }
    }
}
