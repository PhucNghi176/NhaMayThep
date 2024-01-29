using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.HopDong.GetHopDongByIdQuery
{
    public class GetHopDongByIdQueryHandler : IRequestHandler<GetHopDongByIdQuery, HopDongDto>
    {
        private readonly IHopDongRepository _hopdongRepository;
        private readonly IMapper _mapper;
        public GetHopDongByIdQueryHandler(IHopDongRepository hopdongRepository, IMapper mapper)
        {
            _hopdongRepository = hopdongRepository;
            _mapper = mapper;
        }
        public async Task<HopDongDto> Handle(GetHopDongByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _hopdongRepository.FindAnyAsync(x => x.ID == query.Id && x.NgayXoa == null, cancellationToken);
            if (result == null || result.NgayXoa != null)
                throw new NotFoundException($"Không tìm thấy hợp đồng với id: {query.Id}");
            return result.MapToHopDongDto(_mapper);
        }
    }
}
