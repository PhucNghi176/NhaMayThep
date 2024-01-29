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

namespace NhaMayThep.Application.ThongTinChucDanh.GetChucDanhById
{
    public class GetChucDanhByIdQueryHandler : IRequestHandler<GetChucDanhByIdQuery, ChucDanhDto>
    {
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly IMapper _mapper;
        public GetChucDanhByIdQueryHandler(IChucDanhRepository chucDanhRepository, IMapper mapper)
        {
            _chucDanhRepository = chucDanhRepository;
            _mapper = mapper;
        }
        public async Task<ChucDanhDto> Handle(GetChucDanhByIdQuery query, CancellationToken cancellationToken)
        {

            var result = await _chucDanhRepository.FindAnyAsync(x => x.ID ==  query.ID && x.NgayXoa == null, cancellationToken);

            if (result == null || result.NgayXoa != null)
                throw new NotFoundException($"Không tìm thấy chức danh với id: {query.ID}");
            return result.MapToChucDanhDto(_mapper);
        }
    }
}
