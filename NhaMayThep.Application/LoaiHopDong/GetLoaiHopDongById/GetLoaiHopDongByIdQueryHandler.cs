using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var result = await _loaiHopDongReposity.FindAsync(x => x.ID == query.Id, cancellationToken);
            if (result == null || result.NgayXoa != null)
                    throw new NotFoundException($"Not found loai hop dong {query.Id}");
            return result.MapToLoaiHopDongDto(_mapper);
        }
    }
}
