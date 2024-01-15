using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<HopDongDto> Handle(GetHopDongByIdQuery command, CancellationToken cancellationToken)
        {
            var result = await _hopdongRepository.FindAsync(x => x.ID == command.Id, cancellationToken);
            return result.MapToHopDongDto(_mapper);
        }
    }
}
