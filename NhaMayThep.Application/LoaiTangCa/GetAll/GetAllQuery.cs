using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiTangCa.GetAll
{
    public class GetAllQuery : IRequest<List<LoaiTangCaDto>>, IQuery
    {

    }
}