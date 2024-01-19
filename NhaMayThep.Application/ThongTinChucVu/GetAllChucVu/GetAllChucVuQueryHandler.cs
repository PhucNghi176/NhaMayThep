using AutoMapper;
using MediatR;
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
            var list = await _chucVuRepository.FindAllAsync(cancellationToken);
            List<ChucVuDto> result = new List<ChucVuDto>();
            foreach (var item in list)
            {
                if (item.NgayXoa != null)
                    continue;
                var add = item.MapToChucVuDto(_mapper);
                result.Add(add);
            }
            return result;
        }
    }
}
