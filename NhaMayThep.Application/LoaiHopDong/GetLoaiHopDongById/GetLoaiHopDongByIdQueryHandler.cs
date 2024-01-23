using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.LoaiHopDong.GetLoaiHopDongById
{
    public class GetLoaiHopDongByIdQueryHandler : IRequestHandler<GetLoaiHopDongByIdQuery, LoaiHopDongDto>
    {
        private readonly ILoaiHopDongReposity _loaiHopDongReposity;
        private readonly IMapper _mapper;
        public GetLoaiHopDongByIdQueryHandler(ILoaiHopDongReposity loaiHopDongReposity, IMapper mapper)
        {
            _loaiHopDongReposity = loaiHopDongReposity;
            _mapper = mapper;
        }
        public async Task<LoaiHopDongDto> Handle(GetLoaiHopDongByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _loaiHopDongReposity.FindAsync(x => x.ID == query.Id && x.NgayXoa == null, cancellationToken);
            if (result == null || result.NgayXoa != null)
                    throw new NotFoundException($"Không tìm thấy loại hợp đồng với id: {query.Id}");
            return result.MapToLoaiHopDongDto(_mapper);
        }
    }
}
