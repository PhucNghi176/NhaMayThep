using MediatR;

namespace NhaMayThep.Application.LoaiCongTac.Delete
{
    public class DeleteLoaiCongTacCommad : IRequest<string>
    {
        public DeleteLoaiCongTacCommad(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
