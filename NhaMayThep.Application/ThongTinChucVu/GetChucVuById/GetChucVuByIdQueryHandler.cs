using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVu.GetChucVuById
{
    public class GetChucVuByIdQueryHandler : IRequestHandler<GetChucVuByIdQuery, ChucVuDto>
    {
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IMapper _mapper;
        public GetChucVuByIdQueryHandler(IChucVuRepository chucVuRepository, IMapper mapper)
        {
            _chucVuRepository = chucVuRepository;
            _mapper = mapper;
        }
        public async Task<ChucVuDto> Handle(GetChucVuByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _chucVuRepository.FindAsync(x => x.ID ==  query.ID, cancellationToken);
            if (result == null || result.NgayXoa != null)
                throw new NotFoundException($"Not found chuc vu {query.ID}");
            return result.MapToChucVuDto(_mapper);
        }
    }
}
