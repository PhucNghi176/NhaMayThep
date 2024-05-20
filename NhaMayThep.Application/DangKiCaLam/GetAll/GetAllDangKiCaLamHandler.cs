using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.DangKiCaLam.GetAll
{
    public class GetAllDangKiCaLamHandler : IRequestHandler<GetAllDangKiCaLamQuery, List<DangKiCaLamDto>>
    {
        private readonly IDangKiCaLamRepository _repository;
        private readonly IMapper _mapper;
        public GetAllDangKiCaLamHandler(IDangKiCaLamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DangKiCaLamDto>> Handle(GetAllDangKiCaLamQuery request, CancellationToken cancellationToken)
        {
            var lsnp = await _repository.FindAllAsync(c => c.NgayXoa == null, cancellationToken);
            return lsnp.MapToDangKiCaLamDtoList(_mapper);
        }
    }
}
