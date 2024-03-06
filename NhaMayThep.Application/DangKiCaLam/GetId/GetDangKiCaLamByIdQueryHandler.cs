using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiCaLam.Queries.GetDangKiCaLamById
{
    public class GetDangKiCaLamByIdQueryHandler : IRequestHandler<GetDangKiCaLamByIdQuery, DangKiCaLamDto>
    {
        private readonly IMapper _mapper;
        private readonly IDangKiCaLamRepository _repository;

        public GetDangKiCaLamByIdQueryHandler(IDangKiCaLamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DangKiCaLamDto> Handle(GetDangKiCaLamByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(x => x.MaCaLamViec == request.MaCaLamViec, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException($"DangKiCaLam with MaCaLamViec: {request.MaCaLamViec} not found.");
            }

            return _mapper.Map<DangKiCaLamDto>(entity);
        }
    }
}
