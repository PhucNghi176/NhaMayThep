using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.DangKiTangCa.GetId;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiTangCa.Queries.GetDangKiTangCaById
{
    public class GetDangKiTangCaByIdQueryHandler : IRequestHandler<GetByIdQuery, DangKiTangCaDto>
    {
        private readonly IMapper _mapper;
        private readonly IDangKiTangCaRepository _repository;

        public GetDangKiTangCaByIdQueryHandler(IDangKiTangCaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DangKiTangCaDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException($"DangKiTangCa với Id: {request.Id} không tìm thấy .");
            }

            return _mapper.Map<DangKiTangCaDto>(entity);
        }
    }
}
