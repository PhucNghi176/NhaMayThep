using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ChinhSachNhanSu.GetById
{
    public class GetChinhSachNhanByIdQueryHandler : IRequestHandler<GetChinhSachNhanByIdQuery, ChinhSachNhanSuDto>
    {
        private readonly IChinhSachNhanSuRepository _chinhSachNhanSuRepository;
        private readonly IMapper _mapper;
        public GetChinhSachNhanByIdQueryHandler(IChinhSachNhanSuRepository chinhSachNhanSuRepository, IMapper mapper)
        {
            _chinhSachNhanSuRepository = chinhSachNhanSuRepository;
            _mapper = mapper;
        }
        public async Task<ChinhSachNhanSuDto> Handle(GetChinhSachNhanByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _chinhSachNhanSuRepository.FindAsync(x => x.ID == query.ID && x.NguoiXoaID == null);
            if (entity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            return entity.MapToChinhSachNhanSuDto(_mapper);
        }
    }
}
