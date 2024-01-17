using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;


namespace NhaMayThep.Application.ThongTinChucDanh.GetChucDanhById
{
    public class GetChucDanhByIdQueryHandler : IRequestHandler<GetChucDanhByIdQuery, ChucDanhDto>
    {
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly IMapper _mapper;
        public GetChucDanhByIdQueryHandler(IChucDanhRepository chucDanhRepository, IMapper mapper)
        {
            _chucDanhRepository = chucDanhRepository;
            _mapper = mapper;
        }
        public async Task<ChucDanhDto> Handle(GetChucDanhByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _chucDanhRepository.FindAsync(x => x.ID == query.ID, cancellationToken);
            if (result == null || result.NgayXoa != null)
                throw new NotFoundException($"Not found chuc danh {query.ID}");
            return result.MapToChucDanhDto(_mapper);
        }
    }
}
