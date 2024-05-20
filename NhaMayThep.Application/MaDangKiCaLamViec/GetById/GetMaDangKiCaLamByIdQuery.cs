using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.MaDangKiCaLamViec.GetById
{
    public class GetMaDangKiCaLamByIdQuery : IRequest<MaDangKiCaLamViecDTO>, IQuery
    {
        public GetMaDangKiCaLamByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
