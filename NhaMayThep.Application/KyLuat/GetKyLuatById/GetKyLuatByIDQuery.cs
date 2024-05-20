using MediatR;

namespace NhaMayThep.Application.KyLuat.GetKyLuatById
{
    public class GetKyLuatByIDQuery : IRequest<KyLuatDTO>
    {
        public string Id { get; set; }
        public GetKyLuatByIDQuery(string id)
        {
            Id = id;
        }
        public GetKyLuatByIDQuery() { }
    }
}
