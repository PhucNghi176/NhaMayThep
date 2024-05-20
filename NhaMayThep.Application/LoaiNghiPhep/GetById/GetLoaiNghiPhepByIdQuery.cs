using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiNghiPhep.GetById
{
    public class GetLoaiNghiPhepByIdQuery : IRequest<LoaiNghiPhepDto>, IQuery
    {
        public int id;
        public GetLoaiNghiPhepByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
