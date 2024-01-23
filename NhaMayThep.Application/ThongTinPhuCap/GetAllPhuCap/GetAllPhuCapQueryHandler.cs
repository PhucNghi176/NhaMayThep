using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinPhuCap.GetAllPhuCap
{
    public class GetAllPhuCapQueryHandler : IRequestHandler<GetAllPhuCapQuery, List<PhuCapDto>>
    {
        private readonly IPhuCapRepository _phuCapRepository;
        private readonly IMapper _mapper;
        public GetAllPhuCapQueryHandler(IPhuCapRepository phuCapRepository, IMapper mapper)
        {
            _phuCapRepository = phuCapRepository;
            _mapper = mapper;
        }
        public async Task<List<PhuCapDto>> Handle(GetAllPhuCapQuery query, CancellationToken cancellationToken)
        {
            var list = await _phuCapRepository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            List<PhuCapDto> result = new List<PhuCapDto>();
            foreach (var item in list)
            {
                if (item.NgayXoa != null)
                    continue;
                var add = item.MapToPhuCapDto(_mapper);
                result.Add(add);
            }
            return result;
        }
    }
}
