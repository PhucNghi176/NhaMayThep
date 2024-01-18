using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.LoaiCongTac.GetAll
{
    public class GetAllLoaiCongTacQueryHandler : IRequestHandler<GetAllLoaiCongTacQuery, List<LoaiCongTacDto>>
    {
        private readonly ILoaiCongTacRepository _loaiCongTacRepository;
        private readonly IMapper _mapper;

        public GetAllLoaiCongTacQueryHandler(ILoaiCongTacRepository loaiCongTacRepository, IMapper mapper)
        {
            _loaiCongTacRepository = loaiCongTacRepository;
            _mapper = mapper;
        }

        public async Task<List<LoaiCongTacDto>> Handle(GetAllLoaiCongTacQuery request, CancellationToken cancellationToken)
        {
            var list = await _loaiCongTacRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (list is null)
            {
                throw new NotFoundException("Danh Sách Trống");
            }
            return list.MapToLoaiCongTacDtoList(_mapper);
        }
    }
}
