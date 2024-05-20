using MediatR;

namespace NhaMayThep.Application.LichSuNghiPhep.GetByID
{
    public class GetByIdQuery : IRequest<LichSuNghiPhepDto>
    {
        public string Id { get; set; }

        public GetByIdQuery(string id)
        {
            Id = id;
        }
    }
}