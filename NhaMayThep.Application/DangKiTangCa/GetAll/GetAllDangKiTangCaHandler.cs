using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.DangKiTangCa.GetAll
{
    public class GetAllDangKiTangCaHandler : IRequestHandler<GetAllDangKyTangCaQuery, List<DangKiTangCaDto>>
    {
        private readonly IDangKiTangCaRepository _repository;
        private readonly IMapper _mapper;

        public GetAllDangKiTangCaHandler(IDangKiTangCaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DangKiTangCaDto>> Handle(GetAllDangKyTangCaQuery request, CancellationToken cancellationToken)
        {
            var lsnp = await _repository.FindAllAsync(c => c.NgayXoa == null, cancellationToken);
            return lsnp.MapToDangKiTangCaDtoList(_mapper);
        }
    }
}
