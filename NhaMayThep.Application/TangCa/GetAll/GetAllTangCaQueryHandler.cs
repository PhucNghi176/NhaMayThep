using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.TangCa.GetAll
{
    public class GetAllTangCaQueryHandler : IRequestHandler<GetAllTangCaQuery, List<TangCaDto>>
    {
        private readonly ITangCaRepository _repository;
        private readonly IMapper _mapper;
        public GetAllTangCaQueryHandler(ITangCaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TangCaDto>> Handle(GetAllTangCaQuery request, CancellationToken cancellationToken)
        {
            var TangCa = await this._repository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (TangCa == null)
                throw new NotFoundException("Không tìm thấy bất kỳ bảng Tăng Ca nào.");
            return TangCa.MapToTangCaDtoList(_mapper).ToList();

        }
    }
}
