using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.DangKiCaLam.GetAll
{
    public class GetAllDangKiCaLamQuery : IRequest<List<DangKiCaLamDto>>, IQuery
    {
    }
}
