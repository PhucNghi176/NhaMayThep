using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinChucVu.GetAllChucVu
{
    public class GetAllChucVuQueryHandler : IRequestHandler<GetAllChucVuQuery, List<ChucVuDto>>
    {
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IMapper _mapper;
        public GetAllChucVuQueryHandler(IChucVuRepository chucVuRepository, IMapper mapper)
        {
            _chucVuRepository = chucVuRepository;
            _mapper = mapper;
        }
        public async Task<List<ChucVuDto>> Handle(GetAllChucVuQuery query, CancellationToken cancellationToken)
        {
            var list = await _chucVuRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (list == null || list.Count < 0)
                throw new NotFoundException("Không tìm thấy thông tin chức vụ");
            var result = list.MapToChucVuDtoList(_mapper);
            return result;
        }
    }
}
