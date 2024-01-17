using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.CanCuocCongDan.GetCanCuocCongDanById
{
    public class GetCanCuocCongDanByIdQueryHandler : IRequestHandler<GetCanCuocCongDanByIdQuery, CanCuocCongDanDto>
    {
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;
        private readonly IMapper _mapper;

        public GetCanCuocCongDanByIdQueryHandler(ICanCuocCongDanRepository canCuocCongDanRepository, IMapper mapper)
        {
            _canCuocCongDanRepository = canCuocCongDanRepository;
            _mapper = mapper;
        }

        public async Task<CanCuocCongDanDto> Handle(GetCanCuocCongDanByIdQuery request, CancellationToken cancellationToken)
        {
            var CanCuocCongDan = await _canCuocCongDanRepository.FindAsync(x => x.CanCuocCongDan == request.CanCuocCongDan, cancellationToken);

            if (CanCuocCongDan is not null && CanCuocCongDan.NgayXoa is not null)
            {
                return CanCuocCongDan.MapToCanCuocCongDanDto(_mapper);
            }
            throw new NotFoundException($"Khong Tim Thay CanCuocCongDan {request.CanCuocCongDan}");
        }
    }
}
