using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.TangCa.GetId
{
    public class GetTangCaByIdQueryHandler : IRequestHandler<GetTangCaByIdQuery, TangCaDto>
    {
        private readonly ITangCaRepository _repository;
        private readonly IMapper _mapper;


        public GetTangCaByIdQueryHandler(ITangCaRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<TangCaDto> Handle(GetTangCaByIdQuery request, CancellationToken cancellationToken)
        {
            var TangCa = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (TangCa == null)
                throw new NotFoundException($"không tìm thấy Tăng ca với ID : {request.ID} hoặc đã bị xóa.");

            return TangCa.MapToTangCaDto(_mapper);
        }

    }
}
