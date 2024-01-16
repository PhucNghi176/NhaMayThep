using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HopDong.GetAllHopDongQuery
{
    public class GetAllHopDongQueryHandler : IRequestHandler<GetAllHopDongQuery, List<HopDongDto>>
    {
        private readonly IHopDongRepository _hopDongRepository;
        private readonly IMapper _mapper;
        public GetAllHopDongQueryHandler(IHopDongRepository hopDongRepository, IMapper mapper)
        {
            _hopDongRepository = hopDongRepository;
            _mapper = mapper;
        }
        public async Task<List<HopDongDto>> Handle(GetAllHopDongQuery query, CancellationToken cancellationToken)
        {
            var list = await _hopDongRepository.FindAllAsync(cancellationToken);
            List<HopDongDto> result = new List<HopDongDto>();
            foreach(var item in list)
            {
                if(item.NgayXoa != null) 
                    continue;
                var add = item.MapToHopDongDto(_mapper);
                result.Add(add);
            }
            return result;
        }
    }
}
