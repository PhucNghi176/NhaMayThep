using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.DangKiTangCa.GetAll
{
    public class GetAllDangKyTangCaQuery : IRequest<List<DangKiTangCaDto>>, IQuery
    {
    }
}
