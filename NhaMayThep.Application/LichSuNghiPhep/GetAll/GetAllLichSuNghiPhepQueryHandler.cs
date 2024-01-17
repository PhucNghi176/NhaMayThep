using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace NhaMayThep.Application.LichSuNghiPhep.GetAll
{
    public class GetAllLichSuNghiPhepQueryHandler : IRequestHandler<GetAllLichSuNghiPhepQuery, List<LichSuNghiPhepDto>>
    {
        private readonly ILichSuNghiPhepRepository _repository;
        private readonly IMapper _mapper;

        public GetAllLichSuNghiPhepQueryHandler(ILichSuNghiPhepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<LichSuNghiPhepDto>> Handle(GetAllLichSuNghiPhepQuery request, CancellationToken cancellationToken)
        {
            var lsnp = await _repository.FindAllAsync(c => c.NgayXoa == null, cancellationToken);
            return lsnp.MapToLichSuNghiPhepDtoList(_mapper);
        }
    }
}
