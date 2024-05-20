using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.LoaiHopDong.GetAllLoaiHopDong
{
    public class GetAllLoaiHopDongQueryHandler : IRequestHandler<GetAllLoaiHopDongQuery, List<LoaiHopDongDto>>
    {
        private readonly ILoaiHopDongReposity _loaiHopDongReposity;
        private readonly IMapper _mapper;
        public GetAllLoaiHopDongQueryHandler(ILoaiHopDongReposity loaiHopDongReposity, IMapper mapper)
        {
            _loaiHopDongReposity = loaiHopDongReposity;
            _mapper = mapper;
        }
        public async Task<List<LoaiHopDongDto>> Handle(GetAllLoaiHopDongQuery query, CancellationToken cancellationToken)
        {
            var list = await _loaiHopDongReposity.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            List<LoaiHopDongDto> result = new List<LoaiHopDongDto>();
            foreach (var item in list)
            {
                if (item.NgayXoa != null)
                    continue;
                var add = item.MapToLoaiHopDongDto(_mapper);
                result.Add(add);
            }
            return result;
        }
    }
}
